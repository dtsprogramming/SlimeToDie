using UnityEngine.Audio;
using UnityEngine;

// Allows class to be visible when called from another script
[System.Serializable]
public class Sound
{
    // Value to store the sound name
    public string name;

    // Creates and instance of the AudioClip class
    public AudioClip clip;
    // Creates an instance of the AudioMixerGroup class
    public AudioMixerGroup output;
    // Allows spacial blend adjustment from inspector
    [Range(0, 1)] public float spacialBlend;

    // Volume adjuster
    [Range(0f, 1f)]
    public float volume;
    // Pitch adjuster
    [Range(.1f, 3f)]
    public float pitch;

    // Toggle the sound loop
    public bool loop;

    // Creates a hidden instance of the AudioSource class
    [HideInInspector]
    public AudioSource source;
}
