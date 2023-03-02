using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellicDamageTrigger : MonoBehaviour
{
    [Tooltip("Set the damage of the area trigger.")]
    [SerializeField] public int damage = int.MaxValue;
    [Tooltip("Apply this damage only if the player leaves the area.")]
    [SerializeField] public bool applyOnLeave = false;
}
