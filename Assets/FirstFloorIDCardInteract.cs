using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorIDCardInteract : Interactable
{

    public List<string> IDCardText;

    public List<string> GoneText;
    public FirstFloorElevatorInteract elevator;

    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {   
        if(!interacted) {
            PlayerTextboxHandler.Instance.ShowTextLines(IDCardText);
            elevator.HasKeyCard = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            interacted = true;
        } else {
            PlayerTextboxHandler.Instance.ShowTextLines(GoneText);
        }
    }
}
