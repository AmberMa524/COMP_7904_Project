using System.Collections;
using System.Collections.Generic;
using System;
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
    public Canvas phoneUI;
    InputActions ia;
    InputAction interact;
    Action callback;

    List<string> textLines;
    int textIndex = -1;
    bool first = true;
    public bool canEnablePhone = true;

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

    private void Update() {
        tmp.color = PlayerData.getColor();
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

    public bool IsActive()
    {
        return cg.alpha != 0;
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
                textLines = null;
                tmp.text = "";
                first = false;
                if (canEnablePhone)
                    phoneUI.enabled = true;
                callback?.Invoke();
                callback = null;
            }
        }
    }

    public void SetCallback(Action cb)
    {
        callback = cb;
    }

    public void ShowTextLines(List<string> tl)
    {
        textLines = tl;
        jpm.enabled = false;
        ih.enabled = false;
        textIndex = -1;
        cg.alpha = 1;

        if (canEnablePhone)
            phoneUI.enabled = false;
            
        
        if(!first)
        {
            ProceedText(new InputAction.CallbackContext());
        }
    }
}
