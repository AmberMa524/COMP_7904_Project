using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AptDoorInteractable : Interactable
{
    public List<string> cantLeaveText;
    public string destinationScene;
    public static AptDoorInteractable Instance;
    public bool jacketOn = false;

    public void Awake()
    {
        if(Instance)
        {
            Destroy(gameObject);
        } else
        {
            Instance = this;
        }
    }

    void Start()
    {
        interacted = false;
    }

    public override void BeInteractedWith()
    {
        if (!jacketOn)
            PlayerTextboxHandler.Instance.ShowTextLines(cantLeaveText);
        else
            SceneManager.LoadScene(destinationScene);

        collectEntry();
    }
}
