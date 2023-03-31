using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Menu_Clickhandler : MonoBehaviour
{
    public GameObject volume;

    public GameObject subtitles;

    // Start is called before the first frame update
    void Start()
    {
        HideVolume();
        HideSubtitles();
    }

    public void HideVolume() {
        volume.SetActive(false);
    }

    public void ShowVolume() {
        volume.SetActive(true);
    }

    public void HideSubtitles()
    {
        subtitles.SetActive(false);
    }

    public void ShowSubtitles()
    {
        subtitles.SetActive(true);
    }
    public void resetGame() {
        PlayerData.reset();
        PlayerData.startGame();
    }
}
