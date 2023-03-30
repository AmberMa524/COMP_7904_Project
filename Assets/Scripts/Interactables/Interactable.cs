using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool interacted;
    public JournalEntry entry;
    abstract public void BeInteractedWith();

    public void collectEntry() {
        //Debug.Log(gameObject.name);
        //Debug.Log(entry.name);
        if (!interacted)
        {
            PlayerData.addEntry(entry);
            interacted = true;
        }
        else {
            Debug.Log("Already Interacted with");
        }

    }
}
