using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(Collider2D))]
public class Trigger2D : MonoBehaviour {

	public enum TriggerType{CollisionEnter, 
							CollisionExit,
							TriggerEnter,
							TriggerExit};
	public TriggerType triggerType=TriggerType.CollisionEnter;
	private Collider2D m_collider2D;
	public List<Action2D> m_actions = new List<Action2D>();
	// Use this for initialization
	void Start () {
		m_collider2D = GetComponent<Collider2D>();
		Init();
	}
	void Init()
	{
		switch(triggerType)
		{
		case TriggerType.CollisionEnter:
			m_collider2D.isTrigger = false;
			break;
		case TriggerType.CollisionExit:
			m_collider2D.isTrigger = false;
			break;
		case TriggerType.TriggerEnter:
			m_collider2D.isTrigger = true;
			break;
		case TriggerType.TriggerExit:
			m_collider2D.isTrigger = true;
			break;
		}
	}
	
	void DoActions()
	{
		if(m_actions != null)
		{
			foreach(Action2D a in m_actions)
			{
				a.DoAction();
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(triggerType == TriggerType.CollisionEnter)
		{
			DoActions();
		}
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		if(triggerType == TriggerType.CollisionExit)
		{
			DoActions();
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(triggerType == TriggerType.TriggerEnter)
		{
			DoActions();
		}
	}
	void OnTriggerExit2D(Collider2D collider)
	{
		if(triggerType == TriggerType.TriggerExit)
		{
			DoActions();
		}
	}
}
