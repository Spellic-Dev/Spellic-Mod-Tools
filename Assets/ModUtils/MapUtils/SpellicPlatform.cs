using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace MapUtils {

    [System.Serializable]
    public class SpellicPlatformWaypoint {
        public Vector3 position;
        public float waitTime;
        public float speed;
        public AnimationCurve speedCurve;
    }

    [RequireComponent(typeof(NetworkIdentity))]
    [RequireComponent(typeof(NetworkTransform))]
    public class SpellicPlatform : NetworkBehaviour, ISpellicTriggerable
    {
        [Header("Settings")]
        [Tooltip("The platform will move to the first waypoint after reaching the last one.")]
        [SerializeField] private bool loop;
        [Tooltip("A list of waypoints the platform will move to.")]
        [SerializeField] private List<SpellicPlatformWaypoint> waypoints = new List<SpellicPlatformWaypoint>();
        [Tooltip("Set this to true if the platform should be active on start.")]
        [SerializeField] private bool activeOnStart = true;
        [Header("Trigger Settings")]
        [Tooltip("Reference Trigger that can enable this platform.")]
        [SerializeField] public SpellicMapTrigger trigger;
        [Tooltip("Set this to true if the trigger should only execute once.")]
        [SerializeField] public bool triggerOnce = false;
        [Tooltip("Set this to true if the trigger should advance the platform one step.")]
        [SerializeField] public bool advanceOnTrigger = false;

        public void Trigger() {
            throw new System.NotImplementedException();
        }

        public void OnDrawGizmos() {
            // Draw Points
            foreach(var waypoint in waypoints) {
                // Start point green, end point red
                Gizmos.color = waypoint == waypoints[0] ? Color.green : waypoint == waypoints[waypoints.Count - 1] ? Color.red : Color.white;
                Gizmos.DrawSphere(waypoint.position, 0.5f);
            }
            // Draw Lines between points
            for(int i = 0; i < waypoints.Count - 1; i++) {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(waypoints[i].position, waypoints[i + 1].position);
            }
            // Last line if loop
            if(loop && waypoints.Count > 2) {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(waypoints[waypoints.Count - 1].position, waypoints[0].position);
            }
        }
    }
}