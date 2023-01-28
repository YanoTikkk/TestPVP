using UnityEngine;

namespace _App
{
    public class InputManager : IInputManager
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        
        public Vector2 Axis => new(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));

        public Vector2 MouseAxis => new(Input.GetAxis(MouseX), Input.GetAxis(MouseY));

        public bool IsPushButton() => Input.GetMouseButtonDown(0);
    }
}