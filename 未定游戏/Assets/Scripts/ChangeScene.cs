using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour {
    [SerializeField]
    private GameObject SettingPanel;
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]
    private Slider m_slider;
    [SerializeField]
    private Slider s_slider;
    
    [HideInInspector]
    public BeginMusic BeginMusic;
    //public Button button;
    //private Button button;
    //private Image image;

    void Awake()  
    {
        BeginMusic = FindObjectOfType<BeginMusic>();
        m_slider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
        s_slider.value = PlayerPrefs.GetFloat("SoundVolume", 1);
    }
    [SerializeField]
    public void onStartBtnDown() {
        SceneManager.LoadScene("GameNew");
        BeginMusic._BeginSource.Stop();
    }

    public void onDocBtnDown()
    {
        SceneManager.LoadScene("Document");
        
    }

    public void OnEndBtnDown()
    {
        Application.Quit();
    }

    public void OnSettingBtnDown()
    {
        ShowSettingMenu();
        //ChangeImage();
    }
    // Use this for initialization
    void Start () {
        ShowMainMenu();
    }
    public void OnBackBtnDown()
    {
        //PlayerPrefs.Save();
        BeginMusic._BeginSource.volume = m_slider.value;
        PlayerPrefs.Save();
        ShowMainMenu();
    }

    public void OnMusicValueChanged()
    {
        //Debug.Log("slider:"+m_slider.value);
        PlayerPrefs.SetFloat("MusicVolume", m_slider.value);
    }
    public void OnSoundValueChanged()
    {
        //Debug.Log("slider:"+m_slider.value);
        PlayerPrefs.SetFloat("SoundVolume", s_slider.value);
    }
    private void ShowMainMenu()
    {
        MainMenuPanel.SetActive(true);
        SettingPanel.SetActive(false);
    }
    private void ShowSettingMenu()
    {
        MainMenuPanel.SetActive(false);
        SettingPanel.SetActive(true);
    }
  

    // Update is called once per frame
    void Update () {
		
	}
    /*public void ChangeImage()
    {
        button = GameObject.Find("Canvas/MainMenuPanel/AButton").GetComponent<Button>();
        image = button.gameObject.GetComponent<Image>();

        Sprite tmp = new Sprite();
        tmp = Resources.Load("d2", typeof(Sprite)) as Sprite;
        button.interactable = false;
        image.sprite = tmp;

    }*/
}
