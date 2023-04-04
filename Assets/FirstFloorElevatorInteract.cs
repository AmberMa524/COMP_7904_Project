using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstFloorElevatorInteract : Interactable
{
    public List<string> LockedText;

    public List<string> UnlockedText;

    public string destinationScene;

    public GameObject player;

    public bool HasKeyCard = false;


    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        if(!HasKeyCard) {
            PlayerTextboxHandler.Instance.ShowTextLines(LockedText);
        } else {
            PlayerTextboxHandler.Instance.ShowTextLines(UnlockedText);
            SceneManager.LoadScene(destinationScene);
        }
    }
}
