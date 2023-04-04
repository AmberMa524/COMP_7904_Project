using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorLetterInteract : Interactable
{
    public List<string> LetterText;


    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        PlayerTextboxHandler.Instance.ShowTextLines(LetterText);
    }
}
