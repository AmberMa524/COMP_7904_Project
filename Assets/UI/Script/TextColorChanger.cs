using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour
{
    public void changeTextColor() {
        PlayerData.changeColor(gameObject.GetComponent<Image>().color);
    }
}
