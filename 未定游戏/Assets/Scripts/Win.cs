using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Collider2D))]
public class Win : MonoBehaviour {

    [HideInInspector]
    public SouthMusicPlay MainMusic;

    void Awake()  
    {
        MainMusic = FindObjectOfType<SouthMusicPlay>();
    }

	void OnTriggerEnter2D(Collider2D collider)
	{
        MainMusic._MainSource.clip = MainMusic.WinMusic;
        MainMusic._MainSource.Play();
        ResourceManager.Instance().gameMenuCtr.ShowWinPanel();
        ResourceManager.Instance().playerCtr.StopControl();
		//ResourceManager.Instance().gameMenuCtr.ShowWinPanel();
		//ResourceManager.Instance().characterCtr.StopControl();
	}
}
