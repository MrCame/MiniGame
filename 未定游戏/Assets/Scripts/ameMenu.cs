using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ameMenu : MonoBehaviour {
    [SerializeField]
    private GameObject FailPanel;
    [SerializeField]
    private GameObject WinPanel;
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

    public void OnBackBtnDown() {
        SceneManager.LoadScene("StartMenu");
    }
    public void OnRestartBtnDown() {
        SceneManager.LoadScene("GameNew");
    }

}
