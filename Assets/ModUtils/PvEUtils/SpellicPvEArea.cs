using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapUtils
{
    public class SpellicPvEArea : MonoBehaviour, ISpellicTriggerable
    {
        [Header("Area Settings")]
        [Tooltip("List of gameobjects that are player spawns for this area.")]
        [SerializeField] public List<GameObject> playerSpawns;
        [Tooltip("Set this to true if you want the area to be automatically activated on start.")]
        [SerializeField] public bool activateOnStart = false;
        [Tooltip("Set the name of the area.")]
        [SerializeField] public string areaName;
        [Tooltip("Reference Trigger that can enable area.")]
        [SerializeField] public SpellicMapTrigger trigger;
        [Tooltip("Reference to the previous area.")]
        [SerializeField] public SpellicPvEArea previousArea;
        [Tooltip("List of all sections in this area.")]
        [SerializeField] public List<SpellicPvESection> sections;

        public void Trigger() {
            throw new System.NotImplementedException();
        }
    }
}