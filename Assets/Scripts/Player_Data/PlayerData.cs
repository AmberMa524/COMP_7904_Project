using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public static PlayerData Instance;

    public static Color default_color;

    public static int volume_percent;

    public static Color text_color;

    public static List<MapObject> map_list;
    //List of maps

    public static List<JournalEntry> journal_list;

    //List of Journal Entries

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void addMap(MapObject m) {
        int index = m.getIndex();
        if (journal_list[index] == null)
        {
            map_list[index] = m;
        }
        else {
            Debug.Log("Can't Add Map, Index is Already Filled");
        }
    }

    public static void addEntry(JournalEntry e)
    {
        int index = e.getIndex();
        if (journal_list[index] == null)
        {
            journal_list[index] = e;
        }
        else {
            Debug.Log("Can't Add Entry, Index is Already Filled");
        }
    }

    public static void changeVolume(int i) {

        if (i <= 100 && i >= 0) {

            volume_percent = i;

        } else
        {
            Debug.Log("Can't change to this percentage as it is either negative or greater than 100.");
        }
    }

    public static int getVolume() {
        return volume_percent;
    }

    public static void changeColor(Color c) {
        text_color = c;
    }

    public static void reset() {
        default_color = Color.black;
        text_color = default_color;
        volume_percent = 100;
    }
}
