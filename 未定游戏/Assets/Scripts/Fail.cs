using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Fail : MonoBehaviour {

    [HideInInspector]
    public SouthMusicPlay MainMusic;

    void Awake()  
    {
        MainMusic = FindObjectOfType<SouthMusicPlay>();
    }
	
	void OnTriggerEnter2D(Collider2D collider)
	{
        MainMusic._MainSource.clip = MainMusic.LoseMusic;
        MainMusic._MainSource.Play();
        ResourceManager.Instance().gameMenuCtr.ShowFailPanel();
        ResourceManager.Instance().playerCtr.StopControl();
		//ResourceManager.Instance().gameMenuCtr.ShowFailPanel();
		//ResourceManager.Instance().characterCtr.StopControl();
	}
}
