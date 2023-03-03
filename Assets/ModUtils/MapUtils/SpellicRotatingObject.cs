using UnityEngine;

namespace MapUtils
{
    public class SpellicRotatingObject : MonoBehaviour
    {
        [Tooltip("Speed of the rotating object.")]
        public float rotationSpeed = 1f;
        [Tooltip("Direction of the rotation.")]
        public Vector3 rotationVector = Vector3.up;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(rotationVector * (rotationSpeed * Time.deltaTime));
        }
    }
}