using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapUtils
{
    public enum SpellicSpawnTeam
    {
        None,
        Blue,
        Red,
        Mob,
        RedFlag,
        BlueFlag
    }
    public class SpellicMapSpawnPoint : MonoBehaviour
    {
        [Tooltip("Set this to the team that should spawn on this spawn point.")]
        [SerializeField] public SpellicSpawnTeam team;

        void OnDrawGizmos()
        {
            // Draw a semitransparent blue cube at the transforms position
            Color32 c = Color.gray;

            switch (team)
            {
                case SpellicSpawnTeam.Blue:
                    c = Color.blue;
                    break;
                case SpellicSpawnTeam.Red:
                    c = Color.red;
                    break;
                case SpellicSpawnTeam.Mob:
                    c = Color.green;
                    break;
                case SpellicSpawnTeam.RedFlag:
                    c = Color.magenta;
                    break;
                case SpellicSpawnTeam.BlueFlag:
                    c = Color.cyan;
                    break;
            }

            Gizmos.color = c;
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}