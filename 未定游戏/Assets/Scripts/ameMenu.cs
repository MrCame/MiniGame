using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ameMenu : MonoBehaviour {
    [SerializeField]
    private GameObject FailPanel;
    [SerializeField]
    private GameObject WinPanel;

    private Button button1;

    private Image image1;

    private Button button2;

    private Image image2;
    // Use this for initialization
    void Start () {
        HideAllPanel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HideAllPanel()
    {
        WinPanel.SetActive(false);
        FailPanel.SetActive(false);
    }

    public void ShowWinPanel()
    {
        WinPanel.SetActive(true);
        FailPanel.SetActive(false);
    }
    public void ShowFailPanel()
    {
        WinPanel.SetActive(false);
        FailPanel.SetActive(true);
    }

    public void OnBackBtnDownA() {
        SceneManager.LoadScene("StartMenu");
        ChangeImage();
    }

    public void OnBackBtnDownB()
    {
        SceneManager.LoadScene("StartMenu");
        ChangeImageA();
    }
    public void OnRestartBtnDown() {
        SceneManager.LoadScene("GameNew");
    }
    public void ChangeImage()
    {
        button1 = GameObject.Find("Canvas/WinPanel/BackButton").GetComponent<Button>();
        image1 = button1.gameObject.GetComponent<Image>();

        Sprite tmp = new Sprite();
        tmp = Resources.Load("backB", typeof(Sprite)) as Sprite;
        button1.interactable = false;
        image1.sprite = tmp;

    }
    public void ChangeImageA()
    {
        button2 = GameObject.Find("Canvas/FailPanel/BackButton").GetComponent<Button>();
        image2 = button2.gameObject.GetComponent<Image>();

        Sprite tmp = new Sprite();
        tmp = Resources.Load("backB", typeof(Sprite)) as Sprite;
        button2.interactable = false;
        image2.sprite = tmp;

    }

}
