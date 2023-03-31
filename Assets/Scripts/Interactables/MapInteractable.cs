using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteractable : Interactable
{

    public MapObject map_obj;

    // Start is called before the first frame update
    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        collectEntry();
    }

    public void collectMap()
    {
        if (!interacted)
        {
            PlayerData.addMap(map_obj);
            interacted = true;
        }
        else
        {
            Debug.Log("Already Interacted with");
        }

    }
}
