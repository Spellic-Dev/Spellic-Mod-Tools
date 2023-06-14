using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapUtils
{
    public class SpellicPvESection : MonoBehaviour, ISpellicTriggerable
    {
        [Header("Section Settings")]
        [Tooltip("Set this to the area that this section belongs to.")]
        [SerializeField] public SpellicPvEArea area;
        [Tooltip("Set this to true if you want the section to be automatically activated on start.")]
        [SerializeField] public bool activateOnStart = false;
        [Tooltip("Reference Trigger that can enable section.")]
        [SerializeField] public SpellicMapTrigger trigger;
        [Tooltip("List of gameobjects that are mob spawns for this section.")]
        [SerializeField] public List<GameObject> mobSpawns;
        [Tooltip("Last section that will be deactivated when this section is activated.")]
        [SerializeField] public SpellicPvESection lastSection;
        [Tooltip("Set the Level Gate that will be opened when this section is finished.")]
        [SerializeField] public GameObject levelGate;
        [Tooltip("Set the default state of the level gate.")]
        [SerializeField] public bool levelGateState = true;
        [Tooltip("Set this to true if you want the mob spawns to be activated in waves.")]
        [Header("Mob Spawn Settings")]
        [SerializeField] public bool mobSpawnsInWaves = false;
        [Tooltip("The maximum number of mobs that can be spawned in this section.")]
        [SerializeField] public int maxMobs = 10;
        [Tooltip("The delay between waves of mobs.")]
        [SerializeField] public float mobWaveSpawnDelay = 5f;
        [Tooltip("Set this to the desired wave count.")]
        [SerializeField] public int waveCount = 1;

        public void Trigger() {
            throw new System.NotImplementedException();
        }
    }
}