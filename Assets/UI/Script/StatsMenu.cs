using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    public TMP_Text map_value;

    public TMP_Text entries_value;

    public TMP_Text time_value;

    void Start() { 
    
    }

    void Update() {
        map_value.text = "Maps Collected: " + PlayerData.getMapList().Count;
        entries_value.text = "Journal Entries Collected: " + PlayerData.getJournalList().Count;
        float time = PlayerData.getTime();
        string time_String;
        int hours = (int)(time /3600);
        int minutes = (int)(time/60);
        int seconds = (int)(time % 60);
        time_value.text = "Time Played: " + hours + ":" + minutes + ":" + seconds;

    }
}
