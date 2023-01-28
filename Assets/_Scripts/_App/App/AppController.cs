using System.Collections.Generic;
using System.Threading;
using _Config;
using UnityEngine;

namespace _App
{
    public class AppController : MonoBehaviour
    {
        [Header("App Controller Fields")]
        [SerializeField] private AppFields _fields;
        [SerializeField] private CoreConfig _config;

        public static bool Initialized { get; private set; }
        public static CancellationTokenSource CancellationToken { get; private set; }

        private readonly List<IAppInitialize> _initializes = new();
        private readonly List<IAppDestroy> _destroys = new();

        private void Awake()
        {
            Initialize();
        }

        private void OnDestroy()
        {
            var time = Time.time;

            foreach (var obj in _destroys)
                obj.OnDestroy(time);

            CancellationToken?.Cancel();
            CancellationToken = null;
        }

        private void Initialize()
        {
            Initialized = false;

            CancellationToken?.Cancel();
            CancellationToken?.Dispose();

            CancellationToken = new CancellationTokenSource();

            _initializes.Clear();
            _destroys.Clear();

            var inputManager = new InputManager();

            Global.Setup(_fields, _config, inputManager);

            _initializes.Add(_config);

            var time = Time.time;

            foreach (var obj in _initializes)
                obj.OnInitialize(time);

            Application.targetFrameRate = 60;

            _fields.GameManager.StartGame();

            Initialized = true;
        }
    }
}