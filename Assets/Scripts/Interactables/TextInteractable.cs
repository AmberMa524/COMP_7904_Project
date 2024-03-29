using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteractable : Interactable
{
    public List<string> textLines;

    void Start() {
        interacted = false;
    }

    override public void BeInteractedWith()
    {
        PlayerTextboxHandler.Instance.ShowTextLines(textLines);
        collectEntry();
    }
}
