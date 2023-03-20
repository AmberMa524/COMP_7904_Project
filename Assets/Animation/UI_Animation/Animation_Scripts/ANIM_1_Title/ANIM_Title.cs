using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ANIM_Title : MonoBehaviour
{

    Animator animator;

    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Entry");
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Entry" && 
            !animator.IsInTransition(0) && 
            animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f) {

            animator.SetBool("Entry_Passed", true);

        }

        if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Exit" &&
            !animator.IsInTransition(0)) {

            if (sceneName != "") {

                SceneManager.LoadScene(sceneName);

            }

        }
        
    }

    public void StartPressed()
    {
        if (animator.GetBool("Entry_Passed") == true) {

            animator.SetBool("Stay_Passed", true);

        }

    }

}
