using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorStorageRoomInteract : Interactable
{
    public List<string> doorText;

    public JohnnyPlayerMove player;

    public GameObject controlPanel; 


    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        if(!interacted) {
            player.enabled = false;
            controlPanel.SetActive(true);
        }


        //PlayerTextboxHandler.Instance.ShowTextLines(doorText);
    }
}
