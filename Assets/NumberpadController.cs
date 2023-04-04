using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberpadController : MonoBehaviour
{

    private string codeEntered;

    public JohnnyPlayerMove jpm;

    public GameObject door;

    private string password = "1974";
    public TMP_Text inputText;


    void start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNumber(string num) {
        codeEntered += num;

        if(codeEntered.Length > 4) {
                inputText.text = "ERROR";
                codeEntered = "";
        } else {
            inputText.text = codeEntered;
        }
        
    }

    public void clearNumber() {
        jpm.enabled = true;
        gameObject.SetActive(false);
    }

    public void checkCode() {
        if(codeEntered == password) {
            inputText.text = "OK";
            door.transform.rotation = Quaternion.Euler(0,90,0);
            door.transform.position = new Vector3(-12.79f, 0, -8.29f);
            jpm.enabled = true;
            door.GetComponent<FirstFloorStorageRoomInteract>().interacted = true;
            gameObject.SetActive(false);
        } else {
            inputText.text = "ERROR";
            codeEntered = "";
        }
    }
}
