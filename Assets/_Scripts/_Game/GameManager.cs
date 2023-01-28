using System;
using System.Threading.Tasks;
using _App;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace _Game
{
    public sealed class GameManager : NetworkBehaviour, IGameManager
    {
        private const float DelayWinTime = 5f;

        public event Action LevelStarted;
        public event Action LevelFinished;

        private int _playerCount;
        private Text _textWin;

        private readonly SyncDictionary<int, Player> _playersID = new();

        [ClientCallback]
        public async void StartGame()
        {
            while (!NetworkServer.active)
                await Task.Yield();

            while (!NetworkClient.connection.identity.GetComponent<Player>())
                await Task.Yield();

            NetworkServer.OnConnectedEvent += LoadLevel;
            LoadLevel(NetworkServer.localConnection);

            LevelStarted?.Invoke();
        }

        [ClientRpc]
        public async void FinishLevel(int playerId)
        {
            _textWin = Global.Fields.WinText;
            _textWin.gameObject.SetActive(true);
            _textWin.text = $"P{playerId} - WIN!";

            await Task.Delay(TimeSpan.FromSeconds(DelayWinTime));

            NetworkServer.OnConnectedEvent -= LoadLevel;

            _textWin.gameObject.SetActive(false);

            foreach (var player in _playersID)
            {
                player.Value.ResetPlayer();
            }

            _playerCount = 0;
            LevelFinished?.Invoke();
            
            StartGame();
        }

        [Command(requiresAuthority = false)]
        private void LoadLevel(NetworkConnectionToClient networkConnectionToClient)
        {
            _playersID.Clear();

            foreach (var client in NetworkServer.connections)
            {
                _playersID.Add(client.Key, client.Value.identity.GetComponent<Player>());

                Debug.Log(client.Key, client.Value.identity.GetComponent<Player>());
            }

            foreach (var player in _playersID)
            {
                player.Value.Setup(_playerCount);
                _playerCount++;
            }

            LevelStarted?.Invoke();
        }
    }
}