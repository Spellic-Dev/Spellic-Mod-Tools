using UnityEngine;
using Mirror;

namespace MapUtils
{
    public class SpellicRotatingObject : NetworkBehaviour, ISpellicTriggerable
    {
        [Tooltip("Speed of the rotating object.")]
        public float rotationSpeed = 1f;
        [Tooltip("Direction of the rotation.")]
        public Vector3 rotationVector = Vector3.up;
        [Header("Trigger Settings")]
        [Tooltip("Reference Trigger that can enable section.")]
        [SerializeField] public SpellicMapTrigger trigger;
        [Tooltip("Set this to true if you want the area to be automatically activated on start.")]
        [SerializeField] public bool activateOnStart = false;

        public void Trigger()
        {
            throw new System.NotImplementedException();
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(rotationVector * (rotationSpeed * Time.deltaTime));
        }
    }
}