using UnityEngine;

namespace MapUtils
{
    public class SpellicFloatingObject : MonoBehaviour
    {
        // State
        private float bounce;

        [Tooltip("How high the object should bounce.")]
        public float bounceHeight = 0.0001f;
        [Tooltip("How often the object should float.")]
        public float bounceRate = 3.0f;
        [Tooltip("Honestly I don't know anymore. I got this script from Stackoverflow and forgor the link.")]
        public float bounceSync = -0.75f;

        // Calculated Position
        public Vector3 position
        {
            get
            {
                return new Vector3(transform.position.x, transform.position.y + bounce, transform.position.z);
            }
        }

        // Update is called once per frame
        void Update()
        {
            float t = Time.time * bounceRate + position.x * bounceSync;
            bounce = (float)(Mathf.Sin(t)) * bounceHeight;
            transform.position = position;
        }
    }
}