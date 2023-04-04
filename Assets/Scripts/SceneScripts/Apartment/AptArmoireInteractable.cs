using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AptArmoireInteractable : Interactable
{
    public List<string> jacketlessText;
    public List<string> jacketText;

    public GameObject player;

    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        if (AptDoorInteractable.Instance.jacketOn)
            PlayerTextboxHandler.Instance.ShowTextLines(jacketText);
        else
        {
            PlayerTextboxHandler.Instance.ShowTextLines(jacketlessText);
            AptDoorInteractable.Instance.jacketOn = true;
        }
        collectEntry();
        player.GetComponent<PutOnCoat>().activateCoat();
    }
}
