using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_CameraTrack : MonoBehaviour
{
    public GameObject target;


    void Update()
    {
            transform.LookAt(target.transform);
    }
}
