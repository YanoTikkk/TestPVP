using System;
using System.Threading.Tasks;
using _App;
using Mirror;
using UnityEngine;

namespace _Game
{
    public sealed partial class Player
    {
        private const int MaxHit = 3;
        private const int Hit = 1;

        [SyncVar] private int _hitCount;

        [SyncVar] private bool _isCollision = true;
        [SyncVar] private Color _baseColor;

        private void Start()
        {
            _baseColor = _mesh.material.color;
        }

        [ClientCallback]
        private void OnTriggerEnter(Collider other)
        {
            if (_forceSpeed < 1.1f)
                return;

            if (other.TryGetComponent(out Player player))
            {
                if (player._isCollision == false)
                    return;

                player.ChangeColor();

                UpdateHit();
            }
        }

        [ClientCallback]
        private async void ChangeColor()
        {
            Material.color = Global.Config.Main.IgnoreCollisionPlayerColor;
            _isCollision = false;

            await Task.Delay(TimeSpan.FromSeconds(Global.Config.Main.IgnoreCollisionTime));

            Material.color = _baseColor;
            _isCollision = true;
        }
        
        [ClientCallback]
        private void UpdateHit()
        {
            _hitCount += Hit;

            if (_hitCount >= MaxHit)
                OnLevelWin();
        }

        [ClientCallback]
        private void OnLevelWin()
        {
            Global.Fields.GameManager.FinishLevel(_playerNumber);
        }
    }
}