using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerHit : MonoBehaviour
{
    public Animator door;
    public EnemyScript enemy;
    public AudioSource chaseMusic;

    public AudioSource doorBang;
    public void OnTriggerEnter(Collider col){
        if(col.tag == "Player") {
            door.SetBool("Open", true);
            enemy.goToPoint(1);
            chaseMusic.Play();
            doorBang.Play();
        }
    }
}
