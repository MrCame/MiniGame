using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider2D))]
public class Fail : MonoBehaviour {

	
	void OnTriggerEnter2D(Collider2D collider)
	{
        ResourceManager.Instance().gameMenuCtr.ShowFailPanel();
        ResourceManager.Instance().playerCtr.StopControl();
		//ResourceManager.Instance().gameMenuCtr.ShowFailPanel();
		//ResourceManager.Instance().characterCtr.StopControl();
	}
}
