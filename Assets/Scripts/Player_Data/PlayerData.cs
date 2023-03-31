using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public static PlayerData Instance;

    public static Color default_color;

    public static float time;

    public static int volume_percent;

    public static Color text_color;

    public static List<MapObject> map_list;

    public static bool game_started;
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
        if (game_started) {
            time += Time.deltaTime;
        }
    }

    public static void addMap(MapObject m) {
        map_list.Add(m);
    }

    public static void addEntry(JournalEntry e)
    {
        journal_list.Add(e);
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

    public static Color getColor() {
        return text_color;
    }

    public static List<JournalEntry> getJournalList() {
        return journal_list;
    }

    public static List<MapObject> getMapList()
    {
        return map_list;
    }

    public static void startGame() {
        game_started = true;
    }

    public static float getTime() {
        return time;
    }

    public static void reset() {
        default_color = Color.white;
        text_color = default_color;
        volume_percent = 100;
        journal_list = new List<JournalEntry>();
        map_list = new List<MapObject>();
        time = 0.0f;
        game_started = false;
    }
}
