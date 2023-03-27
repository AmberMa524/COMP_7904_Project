using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Menu_Clickhandler : MonoBehaviour
{

    public GameObject maps;

    public GameObject journal;

    public GameObject stats;

    // Start is called before the first frame update
    void Start()
    {
        HideMaps();
        HideJournal();
        HideStats();
    }

    public void HideMaps()
    {
        maps.SetActive(false);
    }

    public void ShowMaps()
    {
        maps.SetActive(true);
    }

    public void HideJournal()
    {
        journal.SetActive(false);
    }

    public void ShowJournal()
    {
        journal.SetActive(true);
    }

    public void HideStats()
    {
        stats.SetActive(false);
    }

    public void ShowStats()
    {
        stats.SetActive(true);
    }
}
