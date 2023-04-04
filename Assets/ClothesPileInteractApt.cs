using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesPileInteractApt : Interactable
{
    public List<string> ClothesInteract;


    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        PlayerTextboxHandler.Instance.ShowTextLines(ClothesInteract);
    }
}
