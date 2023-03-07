using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BusStopInteractable : Interactable
{
    public string destinationScene;
    public List<string> textLines;

    public override void BeInteractedWith()
    {
        PlayerTextboxHandler.Instance.ShowTextLines(textLines);
        PlayerTextboxHandler.Instance.SetCallback(() => SceneManager.LoadScene(destinationScene));
    }
}
