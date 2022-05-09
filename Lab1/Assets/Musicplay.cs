using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Musicplay : MonoBehaviour
{
    public Slider volume;
    // public GameObject ObjectMusic;

    //value from the slider, and it converts to volume level
    private float MusicVolume = 1f;   
    // public AudioSource AudioSource;
    

    // Start is called before the first frame update
    private void Start()
    {
        // ObjectMusic = GameObject.FindWithTag("bgMusic");
        // AudioSource = ObjectMusic.GetComponent<AudioSource>();

        // AudioSource.Play();

        // //set Volume
        // MusicVolume = PlayerPrefs.GetFloat("volume");
        // AudioSource.volume = MusicVolume;
        volume.value = MusicVolume;
    }

    // Update is called once per frame
    private void Update()
    {
        AudioListener.volume = volume.value;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }


    public void updateVolume(float volume) {
        MusicVolume = volume;
    }
}
