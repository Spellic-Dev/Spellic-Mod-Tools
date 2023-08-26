using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellicCameraAnchor : MonoBehaviour
{
[Header("References")]
    [Tooltip("This is the camera position that the camera will look at.")]
    public Vector3 lookPosition;

    // Draw Gismos
    private void OnDrawGizmos() {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.5f);
        // Draw a red sphere at the look position
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(lookPosition, 0.5f);
        // Draw a line between the two
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, lookPosition);
    }
}
