using System.Collections.Generic;
using _Game;
using UnityEngine;
using UnityEngine.UI;

namespace _App
{
    public class AppFields : MonoBehaviour, IAppFields
    {
        [Header("Fields")]
        [SerializeField] private PlayerCamera _playerCamera;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Text _winText;
        [Space]
        [SerializeField] private List<Transform> _spawnPoints;

        public PlayerCamera PlayerCamera => _playerCamera;
        public GameManager GameManager => _gameManager;
        public Text WinText => _winText;
        
        public Transform GetSpawnPoint()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        }
    }
}