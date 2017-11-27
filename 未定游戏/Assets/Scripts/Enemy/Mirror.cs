using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [HideInInspector]
    public bool used;  //检查是否刚刚被使用
    public Transform teleSpot;     //目标传送地点
    private Mirror mr;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        used = false;
        mr = teleSpot.gameObject.GetComponent<Mirror>();   //获取另一个Mirror以检查是否使用
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GetComponentInParent<EnemyMaryController>().dead == true && mr.used==false)  //检测是否刚刚使用过传送
            {
                rb = collision.gameObject.GetComponent<Rigidbody2D>();
                used = true;
                rb.transform.position = new Vector3(teleSpot.position.x , teleSpot.position.y, 0);  
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        mr.used = false;  //允许下一次传送
    }
}
