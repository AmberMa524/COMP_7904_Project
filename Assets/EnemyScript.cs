using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyScript : MonoBehaviour
{
    public float speed = 3;
    public GameObject point;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;

    int currentPointIndex = 0;
    public GameObject currentPoint = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step =  speed * Time.deltaTime;
        if(currentPoint != null) {
            Debug.Log("nowRunning");
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, step);
            if (Vector3.Distance(transform.position, currentPoint.transform.position) < 0.001f)
            {
                currentPointIndex+=1;
                goToPoint(currentPointIndex);
            }
        }

    }


    public void goToPoint(int p) {
        Debug.Log("point");
        switch(p) {
            case 1:
                currentPoint = point; 
                currentPointIndex = 1;
            break;
            case 2: 
                currentPoint = point2; 
                transform.rotation = Quaternion.Euler(0, 180, 0);
            break;
            case 3: 
                currentPoint = point3; 
                gameObject.GetComponent<Animator>().SetBool("OpenWalking",true);
            break;
            case 4: 
                currentPoint = point4; 
                transform.rotation = Quaternion.Euler(0, 270, 0);
            break;
            case 5: 
                transform.rotation = Quaternion.Euler(0, 180, 0);
                currentPoint = point5; 
            break;
        }
    }

    public void OnTriggerEnter(Collider col) {
        if(col.tag == "Player") {
            SceneManager.LoadScene("Title_Scene");
        }
    }
}

