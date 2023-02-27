using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerTextboxHandler : MonoBehaviour
{
    public JohnnyPlayerMove jpm;
    public InteractHandler ih;
    public CanvasGroup cg;
    public TextMeshProUGUI tmp;
    public static PlayerTextboxHandler Instance;
    InputActions ia;
    InputAction interact;

    List<string> textLines;
    int textIndex = 0;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            ia = new InputActions();
            interact = ia.Player.Interact;
            cg.alpha = 0;
        }
    }

    private void OnEnable()
    {
        interact.performed += ProceedText;
        interact.Enable();
    }

    private void OnDisable()
    {
        interact.performed -= ProceedText;
        interact.Disable();
    }

    void ProceedText(InputAction.CallbackContext _)
    {
        if(cg.alpha > 0)
        {
            ++textIndex;
            if (textIndex < textLines.Count)
                tmp.text = textLines[textIndex];
            else
            {
                jpm.enabled = true;
                ih.enabled = true;
                cg.alpha = 0;
            }
        }
    }

    public void ShowTextLines(List<string> tl)
    {
        cg.alpha = 1;
        textLines = tl;
        jpm.enabled = false;
        ih.enabled = false;
        tmp.text = textLines[0];
        textIndex = 0;
    }
}
