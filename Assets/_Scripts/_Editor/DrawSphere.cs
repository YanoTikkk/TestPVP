#if UNITY_EDITOR

using UnityEngine;

namespace _Editor
{
    public class DrawSphere : MonoBehaviour
    {
        [SerializeField] private Color _color = Color.yellow;
        [SerializeField] private float _radius = 1f;

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawSphere(transform.position, _radius);
        }
    }
}

#endif