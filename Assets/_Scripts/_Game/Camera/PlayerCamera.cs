using _App;
using UnityEngine;

namespace _Game
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 _cameraPosition;
        [SerializeField] private Vector3 _cameraRotation;

        [SerializeField] private float _lookXLimitMax = 5f;
        [SerializeField] private float _lookXLimitMin = -30f;
        [SerializeField] private float _lookSpeed = 2f;

        private Transform _cameraTransform;
        private Camera _mainCamera;
        private Vector2 _rotationInput;
        private bool _isEnable;

        public Vector2 RotationInput => _rotationInput;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _cameraTransform = _mainCamera!.transform;
        }

        private void Update()
        {
            if (!_isEnable)
                return;

            RotateCamera();
        }

        public void OnStartGame(Transform target)
        {
            _cameraTransform.SetParent(target);
            _cameraTransform.localPosition = _cameraPosition;
            _cameraTransform.localEulerAngles = _cameraRotation;

            _isEnable = true;
        }

        public void OnStopGame(Transform target)
        {
            _cameraTransform.SetParent(null);
            _cameraTransform.localPosition = Vector3.zero;
            _cameraTransform.localEulerAngles = Vector3.zero;

            _isEnable = false;
        }

        private void RotateCamera()
        {
            _rotationInput.y += Global.Input.MouseAxis.x * _lookSpeed;
            _rotationInput.x += -Global.Input.MouseAxis.y * _lookSpeed;
            _rotationInput.x = Mathf.Clamp(_rotationInput.x, _lookXLimitMin, _lookXLimitMax);

            transform.localRotation = Quaternion.Euler(_rotationInput.x, 0, 0);
        }
    }
}