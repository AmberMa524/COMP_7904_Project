using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapMenu : MonoBehaviour
{

    private List<MapObject> current_map;

    public TMP_Text title;

    public Image map_image;

    public Image default_image;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        current_map = new List<MapObject>();
        updateMap();
        index = 0;
        setUpPage();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("index: " + index);
    }

    public void updateMap()
    {
        current_map = PlayerData.getMapList();
        index = 0;
        setUpPage();
    }

    public void setUpPage()
    {
        if (current_map.Count == 0)
        {
            title.text = "No Maps Have Been Collected";
            map_image = default_image;
        }
        else
        {
            title.text = current_map[index].name;
            map_image = current_map[index].map_image;

        }
    }

    public void changePage(bool forwards)
    {
        if (current_map.Count != 0)
        {

            if (forwards)
            {
                index += 1;
            }
            else
            {
                index += -1;
            }

            if (index > current_map.Count)
            {
                index = 0;
            }
            else if (index < 0)
            {
                index = current_map.Count - 1;
            }
            else
            {
                Debug.Log("Index within range");
            }

        }
        else
        {
            Debug.Log("Cannot Change Map, as there are no Maps.");
        }
        setUpPage();
    }
}
