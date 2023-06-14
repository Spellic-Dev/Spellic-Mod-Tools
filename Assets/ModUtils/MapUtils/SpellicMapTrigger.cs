using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace MapUtils {
    public interface ISpellicTriggerable
    {
        void Trigger();
    }

    [RequireComponent(typeof(Collider))]
    public class SpellicMapTrigger : MonoBehaviour, ISpellicTriggerable
    {
        [Header("Trigger Settings")]
        [Tooltip("Set this to true if you want the trigger to be active on start.")]
        [SerializeField] public bool activeOnStart = true;
        [Tooltip("Set this to true if you want the trigger to be activated by players.")]
        [SerializeField] public bool playerTrigger = false;
        [Tooltip("Set this to true if you want the trigger to be activated by spells.")]
        [SerializeField] public bool spellTrigger = false;
        [Tooltip("Set this to true if you want the trigger to be activated when something enters it.")]
        [SerializeField] public bool triggerOnEnter = false;
        [Tooltip("Set this to true if you want the trigger to be activated when something exits it.")]
        [SerializeField] public bool triggerOnExit = false;
        [Tooltip("Set this to true if you want the trigger to be executed only once.")]
        [SerializeField] public bool executeOnce = false;
        private List<ISpellicTriggerable> objectsInTrigger = new List<ISpellicTriggerable>();
        private bool executed = false;
        public void Subscribe(ISpellicTriggerable triggerAble) {
            objectsInTrigger.Add(triggerAble);
        }
        public void Unsubscribe(ISpellicTriggerable triggerAble) {
            objectsInTrigger.Remove(triggerAble);
        }
        public void Execute() {
            if(!NetworkServer.active) {
                return;
            }
            if(executeOnce && executed) {
                return;
            }
            executed = true;
            if(activeOnStart == false) {
                return;
            }
            foreach(ISpellicTriggerable triggerAble in objectsInTrigger) {
                triggerAble.Trigger();
            }
        }
        private void OnTriggerEnter(Collider other) {
            if(triggerOnEnter) {
                if(playerTrigger && other.gameObject.tag == "Player") {
                    Execute();
                }
                if(spellTrigger && other.gameObject.tag == "Spell") {
                    Execute();
                }
            }
        }
        private void OnTriggerExit(Collider other) {
            if(triggerOnExit) {
                if(playerTrigger && other.gameObject.tag == "Player") {
                    Execute();
                }
                if(spellTrigger && other.gameObject.tag == "Spell") {
                    Execute();
                }
            }
        }
        public void Trigger() {
            // set this trigger active
            activeOnStart = true;
        }
    }
}