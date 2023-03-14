using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Clickhandler : MonoBehaviour
{
    public GameObject menu;

    public GameObject phone;

    public GameObject settings;

    public GameObject exitcheck;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("All Hidden");
        HideMenu();
        HideSettings();
        HideExitCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideMenu() {
        Debug.Log("Hide Menu");
        menu.SetActive(false);
        phone.SetActive(true);
    }

    public void ShowMenu() {
        Debug.Log("Show Menu");
        menu.SetActive(true);
        phone.SetActive(false);
    }

    public void HideSettings()
    {
        Debug.Log("Hide Settings");
        settings.SetActive(false);
    }

    public void ShowSettings()
    {
        Debug.Log("Show Settings");
        settings.SetActive(true);
    }

    public void HideExitCheck()
    {
        Debug.Log("Hide Exit");
        exitcheck.SetActive(false);
    }

    public void ShowExitCheck()
    {
        Debug.Log("Show Exit");
        exitcheck.SetActive(true);
    }
}
