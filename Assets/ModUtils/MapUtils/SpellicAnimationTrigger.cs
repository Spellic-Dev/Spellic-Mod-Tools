using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace MapUtils
{
    [System.Serializable]
    public class SpellicNetworkAnimation
    {
        public List<Animation> animations;
    }

    [RequireComponent(typeof(NetworkIdentity))]
    public class SpellicAnimationTrigger : NetworkBehaviour, ISpellicTriggerable
    {
        [Header("Animation Settings")]
        [Tooltip("List of animations that will be played.")]
        [SerializeField] public List<SpellicNetworkAnimation> animationSteps;
        [Tooltip("Set this to true if you want the animation to be played in reverse.")]
        [SerializeField] public bool playReverse = false;
        [Tooltip("Set this to true if you want the animation to be looped.")]
        [SerializeField] public bool loop = false;
        [Tooltip("Set this to true if you want the animation to be played from the start.")]
        [SerializeField] public bool animateFromStart = false;
        [Header("Trigger Settings")]
        [Tooltip("Reference Trigger that can enable section.")]
        [SerializeField] public SpellicMapTrigger trigger;
        [Tooltip("Set this to true if the trigger should only execute once.")]
        [SerializeField] public bool triggerOnce = false;

        public void Trigger() {
            throw new System.NotImplementedException();
        }
    }
}