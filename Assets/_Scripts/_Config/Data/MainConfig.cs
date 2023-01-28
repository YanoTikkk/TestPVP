using UnityEngine;

namespace _Config
{
    [CreateAssetMenu(fileName = "MainConfig", menuName = "Configurations/MainConfig", order = 0)]
    public class MainConfig : ScriptableObject, IMainConfig
    {
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _pushDistance;
        [SerializeField] private float _slowSpeedTime;
        [SerializeField] private float _ignoreCollisionTime;
        [Space] 
        [SerializeField] private Color _ignoreCollisionPlayerColor;
        
        public float PlayerSpeed => _playerSpeed;
        public float PushDistance => _pushDistance;
        public float SlowSpeedTime => _slowSpeedTime;
        public float IgnoreCollisionTime => _ignoreCollisionTime;
        public Color IgnoreCollisionPlayerColor => _ignoreCollisionPlayerColor;
    }
}