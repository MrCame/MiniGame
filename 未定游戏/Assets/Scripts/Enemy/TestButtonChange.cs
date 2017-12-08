using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestButtonChange : MonoBehaviour {
    //public Button button;
    private Button button;

    private Image image;

    void Start()
    {

    }


    public void ChangeImage()
    {
        button = GameObject.Find("Canvas/Panel/return").GetComponent<Button>();
        image = button.gameObject.GetComponent<Image>();

        Sprite tmp = new Sprite();
        tmp = Resources.Load("backB", typeof(Sprite)) as Sprite;
        button.interactable = false;
        image.sprite = tmp;

    }

    void Update()
    {

    }
}
