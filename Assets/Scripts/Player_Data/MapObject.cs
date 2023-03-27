using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    public Image map_image;

    private string name;

    private int index;

    public MapObject(Image new_image, string name_string, int number) {
        map_image = new_image;
        name = name_string;
        index = number;
    }

    public Image getImage()
    {

        return map_image;

    }

    public string getName()
    {

        return name;

    }

    public int getIndex()
    {

        return index;

    }

    public void setDescription(Image im)
    {
        map_image = im;
    }

    public void setName(string title)
    {
        name = title;
    }

    public void setIndex(int number)
    {
        index = number;
    }

}
