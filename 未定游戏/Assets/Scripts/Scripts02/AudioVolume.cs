using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class AudioVolume : MonoBehaviour {

	private float m_audioVolume=0;
	private AudioSource m_audioSource;
	// Use this for initialization
	void Start () {
		m_audioVolume = PlayerPrefs.GetFloat ("AudioVolume", 1);
		m_audioSource = GetComponent<AudioSource>();
		m_audioSource.volume = m_audioVolume;
		m_audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
