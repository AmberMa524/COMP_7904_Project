using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorIDCardInteract : Interactable
{

    public List<string> IDCardText;
    public FirstFloorElevatorInteract elevator;

    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        PlayerTextboxHandler.Instance.ShowTextLines(IDCardText);
        elevator.HasKeyCard = true;
        Destroy(gameObject);
    }
}
