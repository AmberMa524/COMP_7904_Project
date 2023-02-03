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
        HideMenu();
        HideSettings();
        HideExitCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideMenu() {
        menu.SetActive(false);
        phone.SetActive(true);
    }

    public void ShowMenu() {
        menu.SetActive(true);
        phone.SetActive(false);
    }

    public void HideSettings()
    {
        settings.SetActive(false);
    }

    public void ShowSettings()
    {
        settings.SetActive(true);
    }

    public void HideExitCheck()
    {
        exitcheck.SetActive(false);
    }

    public void ShowExitCheck()
    {
        exitcheck.SetActive(true);
    }
}
