using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AptArmoireInteractable : Interactable
{
    public List<string> jacketlessText;
    public List<string> jacketText;

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
    }
}
