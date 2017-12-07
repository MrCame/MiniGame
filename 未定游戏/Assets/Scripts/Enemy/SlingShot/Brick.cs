using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider2D))]
public class Brick : MonoBehaviour {

    //public float Health = 50;

    public enum TriggerType { CollisionEnter, CollisionExit, TriggerEnter, TriggerExit};

    public TriggerType triggerType = TriggerType.CollisionEnter;
    private Collider2D collider2D;

    //private List<Bridge> bridges = new List<Bridge>();
    public Bridge brige;

    void Start()
    {
        collider2D = GetComponent<Collider2D>();
        Init();
    }

    void Init()
    {
        switch (triggerType)
        {
            case TriggerType.CollisionEnter:
                collider2D.isTrigger = false;
                break;
            case TriggerType.CollisionExit:
                collider2D.isTrigger = false;
                break;
            case TriggerType.TriggerEnter:
                collider2D.isTrigger = true;
                break;
            case TriggerType.TriggerExit:
                collider2D.isTrigger = true;
                break;
        }
    }

    void Update()
    {
        
    }

    void DoActions()
    {
        if (brige != null)
        {
            brige.DoAction();
        }
    }

    // 回调方法
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.GetComponent<Rigidbody2D>() == null)return;
        //float damage = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
        //Health -= damage;

        //if (Health <= 0)Debug.Log("touch");
        //Destroy(this.gameObject);

        if (triggerType == TriggerType.CollisionEnter)
        {
            Debug.Log("CollisionEnter2D");
            DoActions();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (triggerType == TriggerType.CollisionExit)
        {
            Debug.Log("CollisionExit2D");
            DoActions();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerType == TriggerType.TriggerEnter)
        {
            Debug.Log("TriggerEnter2D");
            DoActions();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerType == TriggerType.TriggerExit)
        {
            Debug.Log("TriggerExit2D");
            DoActions();
        }
        
    }
}
