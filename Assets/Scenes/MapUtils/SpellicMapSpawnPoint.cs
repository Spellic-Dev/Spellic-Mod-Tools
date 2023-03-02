using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpellicSpawnTeam
{
    None,
    Blue,
    Red
}
public class SpellicMapSpawnPoint : MonoBehaviour
{
    [Tooltip("Set this to the team that should spawn on this spawn point.")]
    [SerializeField] public SpellicSpawnTeam team;
}
