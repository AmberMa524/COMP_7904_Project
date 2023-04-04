using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AptCutscene : MonoBehaviour
{
    public JohnnyPlayerMove jpm;
    public InteractHandler ih;
    public List<AT_StealMainCamera> cameras;
    public AT_StealMainCamera postCutsceneCam;
    List<List<string>> dialogue;
    public CanvasGroup blackScreen;
    List<Action> framelies;
    Action framelyFunc;
    PlayerTextboxHandler pth;
    public Canvas phoneUI;

    void DisablePlayer()
    {
        jpm.enabled = false;
        ih.enabled = false;
    }

    void EnablePlayer()
    {
        jpm.enabled = true;
        ih.enabled = true;
    }

    void Start()
    {
        
        phoneUI.enabled = false;
        pth = PlayerTextboxHandler.Instance;
        pth.canEnablePhone = false;
        dialogue = new();
        framelies = new();

        List<string> d = new()
        { 
            "???: HELLO",
            "???: JODI",
            "???: YOU KNOW WHERE I AM",
            "???: COME TO ME"
        };
        dialogue.Add(d);
        d = new() {
            "Jodi: ...",
            "Jodi: What time is it? How long have I been out...",
            "Jodi: That voice again..."
        };
        dialogue.Add(d);
        d = new() {
            "TV: In breaking news today, a miraculous development in the case of CEO Harmon West who was pronounced dead after falling into a coma last month due to a stroke.",
            "TV: Harmon was admitted to experimental treatment under the pharmaceutical company BNA,",
            "TV: and they have reported the treatment as successful and Harmon�s prior reported status as a false report.",
            "TV: BNA says he will be making a full recovery from the stroke.",
            "TV: This is the third person in the past year that BNA�s procedure has worked on and they say they hope to continue administering it."
        };
        dialogue.Add(d);
        d = new() {
            "Jodi: An imbecilic, spoiled, infantile shell of a man like him couldn�t even remember his own name, let alone �revive� himself!",
            "Jodi: That�s the final nail, I�m going there, I�m finding whatever they are keeping there.",
            "Jodi: It�s time for the world to see what I see.",
            "Jodi: I�ll need to get my coat and get going."
        };
        dialogue.Add(d);

        pth.SetCallback(() => {
            framelyFunc = framelies[0];
            DisablePlayer();
        });
        pth.ShowTextLines(dialogue[0]);

        framelies.Add(() =>
        {
            blackScreen.alpha -= 0.005f;
            if(blackScreen.alpha <= 0)
            {
                Destroy(blackScreen.gameObject);
                pth.ShowTextLines(dialogue[1]);
                framelyFunc = framelies[1];
            }
        });

        framelies.Add(() =>
        {            
            pth.SetCallback(() =>
            {
                DisablePlayer();
                cameras[0].StealCamera();
                pth.ShowTextLines(dialogue[2]);
                framelyFunc = framelies[2];
            });

            framelyFunc = null;
        });

        framelies.Add(() =>
        {
            
            pth.SetCallback(() =>
            {
                DisablePlayer();
                pth.ShowTextLines(dialogue[3]);
                cameras[1].StealCamera();
                framelyFunc = framelies[3];
            });

            framelyFunc = null;
        });

        framelies.Add(() =>
        {
            pth.SetCallback(() =>
            {
                postCutsceneCam.StealCamera();
                phoneUI.enabled = true;
                pth.canEnablePhone = true;
                EnablePlayer();
                Destroy(gameObject);
            });

            framelyFunc = null;
        });


    }

    void FixedUpdate()
    {
        framelyFunc?.Invoke();
    }
}
