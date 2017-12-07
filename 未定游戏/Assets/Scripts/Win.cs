using UnityEngine;
using System.Collections;
[RequireComponent (typeof(Collider2D))]
public class Win : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D collider)
	{
        ResourceManager.Instance().gameMenuCtr.ShowWinPanel();
        ResourceManager.Instance().playerCtr.StopControl();
		//ResourceManager.Instance().gameMenuCtr.ShowWinPanel();
		//ResourceManager.Instance().characterCtr.StopControl();
	}
}
