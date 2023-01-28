using UnityEngine;

namespace _App
{
    public interface IInputManager
    {
        Vector2 Axis { get; }
        Vector2 MouseAxis { get; }

        bool IsPushButton();
    }
}