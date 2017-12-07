using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Animation))]
public class Action2D : MonoBehaviour {

	private Animation m_anim;
	private bool m_isPlayed = false;
	// Use this for initialization
	void Start () {
		m_anim = GetComponent<Animation>();
	}

	public void DoAction()
	{
		if(!m_isPlayed)
		{
			m_anim.Play ();
			m_isPlayed = true;
		}
	}
}
