using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractHandler : MonoBehaviour
{
    List<Interactable> objectsInRange;
    InputActions ia;
    InputAction interact;
    public static InteractHandler Instance;

    private void Awake()
    {
        if(!Instance)
        {
            ia = new InputActions();
            interact = ia.Player.Interact;
            objectsInRange = new();
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        interact.Enable();
        interact.performed += Interact;
    }

    private void OnDisable()
    {
        interact.Disable();
        interact.performed -= Interact;
    }

    private void Interact(InputAction.CallbackContext _)
    {
        if (objectsInRange.Count > 0)
            objectsInRange[0].BeInteractedWith();
    }

    private void OnTriggerEnter(Collider other)
    {
        Interactable i = other.GetComponent<Interactable>();
        if(i)
            objectsInRange.Add(i);
    }

    private void OnTriggerExit(Collider other)
    {
        Interactable i = other.GetComponent<Interactable>();
        if(i)
            objectsInRange.Remove(i);
    }
}
