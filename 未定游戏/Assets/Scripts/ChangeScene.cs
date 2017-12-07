using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {
    [SerializeField]
    private GameObject SettingPanel;
    [SerializeField]
    private GameObject MainMenuPanel;
    [SerializeField]

    public void onStartBtnDown() {
        SceneManager.LoadScene("GameNew");
    }

    public void OnEndBtnDown()
    {
        Application.Quit();
    }

    public void OnSettingBtnDown()
    {
        ShowSettingMenu();
    }
    // Use this for initialization
    void Start () {
        ShowMainMenu();
    }
    public void OnBackBtnDown()
    {
        //PlayerPrefs.Save();
        ShowMainMenu();
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
}
