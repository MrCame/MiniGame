using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {

	public MovieTexture m_movie;
	private float m_playTime;
	private bool m_isPlayed = false;
	private AudioClip m_audioClip;
	// Use this for initialization
	void Start () {
		if(m_movie != null)
		{
			m_movie.Play ();
			m_audioClip = m_movie.audioClip;
			if(m_audioClip != null)
			{
				AudioSource source = this.gameObject.AddComponent<AudioSource>();
				source.clip = m_audioClip;
				source.volume = PlayerPrefs.GetFloat("AudioVolume", 1);
				source.Play();
			}
		}
		else
		{
			Debug.LogError("PlayMovie/Start:m_movie is null.");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(m_movie == null)
			return;
		if(!m_isPlayed && m_movie.isPlaying)
		{
			m_playTime = Time.time;
			m_isPlayed = true;
		}
		if(Time.time - m_playTime - m_movie.duration > 0.1f)
		{
			StopMovieAndLoadLevel();
		}
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			StopMovieAndLoadLevel();
		}
	}

	void StopMovieAndLoadLevel()
	{
		m_movie.Stop ();
		Application.LoadLevel(GameSetting.MainMenuSceneIndex);
	}

	void OnGUI()
	{
		if(m_movie!=null && m_movie.isPlaying)
		{
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), m_movie, ScaleMode.ScaleToFit);
		}
	}
}
