using UnityEngine;

namespace _Config
{
    public interface IMainConfig
    {
        float PlayerSpeed { get; }
        float PushDistance { get; }
        float SlowSpeedTime { get; }
        
        float IgnoreCollisionTime { get; }

        Color IgnoreCollisionPlayerColor { get; }
    }
}