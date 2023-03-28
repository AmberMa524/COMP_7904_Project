using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeAudioPercentage : MonoBehaviour
{
    public Slider current_slider;

    public TMP_Text volume_text;

    void Start() {
        current_slider.GetComponent<Slider>().value = PlayerData.getVolume();
        volume_text.text = " " + PlayerData.getVolume() + "%";
    }

    public void changeAudioPercentage() {
        int i = (int) current_slider.GetComponent<Slider>().value;
        current_slider.GetComponent<Slider>().value = i;
        volume_text.text = " " + i + "%";
        PlayerData.changeVolume(i);
    }
}
