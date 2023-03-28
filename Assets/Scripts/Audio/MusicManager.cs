using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    //public static AudioManager Instance;
    public AudioSource[] audiolist;

    public int source_index;

    public float volume_value;

    public bool is_looping;

    private AudioSource currentaudio;

    private void Start()
    {
        audiolist = gameObject.GetComponents<AudioSource>();
        Debug.Log(audiolist[0]);
        changeSource(source_index);
        changeVolume(volume_value);
        Loop(is_looping);
        play();
    }

    private void Update() {
        changeSource(source_index);
        changeVolume(volume_value);
    }

    public void play()
    {
        if (audiolist.Length != 0 && currentaudio != null)
        {
            currentaudio.Play();
        }
    }

    public void pause()
    {
        if (audiolist.Length != 0 && currentaudio != null)
        {
            currentaudio.Pause();
        }
    }

    public void stop()
    {
        if (audiolist.Length != 0 && currentaudio != null)
        {
            currentaudio.Stop();
        }
    }

    public void changeSource(int i)
    {
        if (i <= audiolist.Length && i >= 0)
        {
            currentaudio = audiolist[i];
            //Debug.Log("Valid Index");
        }
        else
        {
            //Debug.Log("Invalid Index");
        }
    }

    public void changeVolume(float vol) {
        
        if (currentaudio != null)
        {

            if (vol >= 100.0f) {
                currentaudio.volume = 1.0f;
                volume_value = 1.0f;
            } else if (vol <= 0.0f) {
                currentaudio.volume = 0.0f;
                volume_value = 0.0f;
            } else {
                currentaudio.volume = (PlayerData.getVolume() / 100.0f) * vol;
            }
        }
    }

    public void Loop(bool loop_bool) {

         if (currentaudio != null)
            {
                currentaudio.loop = loop_bool;
            }
    }
}
