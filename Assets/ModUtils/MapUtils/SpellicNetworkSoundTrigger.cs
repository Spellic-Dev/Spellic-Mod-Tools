using UnityEngine.Audio;
using UnityEngine;
using Mirror;

public class SpellicNetworkSoundTrigger : NetworkBehaviour
{
    [Tooltip("Displays if this sound has already been played.")]
    [SyncVar] public bool hasBeenPlayed = false;
    [Tooltip("Set if this sound can only be triggered once.")]
    [SyncVar] public bool playOnce = true;
    [Tooltip("The audiofile to play.")]
    public AudioClip audioClip;
}
