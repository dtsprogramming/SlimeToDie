using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    // Stores an array of the custom sound class
    public Sound[] sounds;

    // Awake is called before Start
    void Awake()
    {
        // Loops through each sound in the Sound array
        foreach (Sound sound in sounds)
        {
            // Stores an AudioSource
            sound.source = gameObject.AddComponent<AudioSource>();

            // Sets the Sound class values equal to their corresponding AudioSource values
            sound.source.outputAudioMixerGroup = sound.output;
            sound.source.clip = sound.clip;
            sound.source.spatialBlend = sound.spacialBlend;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    // Start is called before the first frame
    private void Start()
    {
        // Plays the background music
        Play("Theme");
    }

    // Function used to play the passed in sound
    public void Play(string name)
    {
        // Sets the sound equal to the sound from the array with the same name
        Sound sound = Array.Find(sounds, sound => sound.name == name);

        // Checks if the sound exists
        if (sound != null)
        {
            // Calls the Play() method from AudioSource
            sound.source.Play();
        }
    }
}
