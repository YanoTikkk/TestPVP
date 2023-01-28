using _App;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

namespace _Game
{
    public sealed partial class Player : NetworkBehaviour
    {
        [SerializeField] private NavMeshAgent _navMesh;
        [SerializeField] private MeshRenderer _mesh;

        private bool IsPush => Global.Input.IsPushButton();
        public Material Material => _mesh.material;

        private void Update()
        {
            if (!isLocalPlayer || !_navMesh.enabled)
                return;

            RotatePlayer();
            ForceSpeed();
        }

        private void FixedUpdate()
        {
            if (!isLocalPlayer || !_navMesh.enabled)
                return;

            _navMesh.velocity = GetDirection();
        }

        public void Setup(int index)
        {
            _playerNumber = index;
        }

        public override void OnStartLocalPlayer()
        {
            Global.Fields.PlayerCamera.OnStartGame(transform);
        }

        public override void OnStopLocalPlayer()
        {
            Global.Fields.PlayerCamera.OnStopGame(transform);
        }

        [Client]
        public void ResetPlayer()
        {
            _hitCount = 0;
            transform.position = Global.Fields.GetSpawnPoint().position;
            transform.rotation = Global.Fields.GetSpawnPoint().rotation;
        }
    }
}