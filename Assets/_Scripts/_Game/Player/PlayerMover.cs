using _App;
using UnityEngine;

namespace _Game
{
    public sealed partial class Player
    {
        private float _forceSpeed;
        private float _horizontal;
        private float _vertical;

        private Vector3 GetDirection()
        {
            var direction = new Vector3(Global.Input.Axis.x, 0f, Global.Input.Axis.y);
            direction = transform.TransformDirection(direction);

            if (_forceSpeed <= 1f)
                _forceSpeed = 1f;

            direction *= Global.Config.Main.PlayerSpeed * _forceSpeed;

            return direction;
        }

        private void RotatePlayer()
        {
            transform.eulerAngles = new Vector2(0, Global.Fields.PlayerCamera.RotationInput.y);
        }

        private void ForceSpeed()
        {
            _forceSpeed -= Global.Config.Main.SlowSpeedTime * Time.deltaTime;

            if (IsPush)
            {
                _forceSpeed = Global.Config.Main.PushDistance;
            }
        }
    }
}