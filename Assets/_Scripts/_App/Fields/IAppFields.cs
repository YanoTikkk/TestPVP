using _Game;
using UnityEngine;
using UnityEngine.UI;

namespace _App
{
    public interface IAppFields
    {
        PlayerCamera PlayerCamera { get; }
        GameManager GameManager { get; }
        Text WinText { get; }
        Transform GetSpawnPoint();
    }
}