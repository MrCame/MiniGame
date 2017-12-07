using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    public AudioClip AudioWalk;
    public AudioClip AudioJump;
    public AudioClip AudioAttack;
    public AudioClip AudioHurt;
    private AudioSource source;
	// Use this for initialization
    void Awake()  
    {  
       source = this.gameObject.AddComponent<AudioSource>(); 
       source.loop = false;
       source.volume = PlayerPrefs.GetFloat("SoundVolume", 1);
    }

	public void MakeAudio(int Move, bool Jump, bool Attack, bool Hurt)
    {
        if (Hurt)
        {
            source.clip = AudioHurt;
            source.Play();
        }
        else if(Attack)
        {
            source.clip = AudioAttack;
            source.Play();
        }
        else if(Jump)
        {
            source.clip = AudioJump;
            source.Play();
        }
        else if(!source.isPlaying && Move == 1)
        {
            source.clip = AudioWalk;
            source.Play(); 
        }
    }
}
