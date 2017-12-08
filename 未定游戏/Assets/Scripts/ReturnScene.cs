using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnScene : MonoBehaviour {
    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject PanelA;
    [SerializeField]
    private GameObject PanelB;
    [SerializeField]
    private GameObject PanelC;
    [SerializeField]
    private GameObject PanelD;
    [SerializeField]
    private GameObject PanelE;

    // Use this for initialization
    void Start () {
        ShowPanel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void onReturn() {
        SceneManager.LoadScene("StartMenu");
    }

    
    private void ShowPanel()
    {
       Panel.SetActive(true);
       PanelA.SetActive(false);
       PanelB.SetActive(false);
       PanelC.SetActive(false);
       PanelD.SetActive(false);
       PanelE.SetActive(false);
       
    }

    public void ShowPanelA()
    {
        PanelA.SetActive(true);
        Panel.SetActive(false);

    }
    public void ShowPanelB()
    {
        PanelB.SetActive(true);
        Panel.SetActive(false);

    }
    public void ShowPanelC()
    {
        PanelC.SetActive(true);
        Panel.SetActive(false);

    }
    public void ShowPanelD()
    {
        PanelD.SetActive(true);
        Panel.SetActive(false);

    }
    public void ShowPanelE()
    {
        PanelE.SetActive(true);
        Panel.SetActive(false);

    }
    public void onBack() {
        ShowPanel();
    }


}
