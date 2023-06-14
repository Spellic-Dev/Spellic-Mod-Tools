using UnityEngine;
using Mirror;

namespace MapUtils
{
    public class SpellicNetworkConveyor : NetworkBehaviour
    {
        [Header("Settings")]
        [Tooltip("Direction of the conveyor.")]
        public Vector3 direction = new Vector3(10, 0, 0);
        [Tooltip("Speed of the conveyor.")]
        public float speed = 1f;
        [Tooltip("Additional speed for props.")]
        public float propForce = 1f;
    }
}