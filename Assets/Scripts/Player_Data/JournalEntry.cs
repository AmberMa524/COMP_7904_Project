using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalEntry : MonoBehaviour
{
    public string description;

    public string name;

    public int index;

    public JournalEntry(string desc, string title, int number) {
        description = desc;
        name = title;
        index = number;
    }

    public string getDescription() {

        return description;
    
    }

    public string getName()
    {

        return name;

    }

    public int getIndex()
    {

        return index;

    }

    public void setDescription(string desc) {
        description = desc;
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
