using Mirror;
using UnityEngine;

namespace _Game
{
    public sealed partial class Player
    {
        [SyncVar] private int _playerNumber;

        private void OnGUI()
        {
            GUI.Box(new Rect(1500f + _playerNumber * 300, 250f, 100f, 25f), $"P{_playerNumber}: {_hitCount}");
        }
    }
}