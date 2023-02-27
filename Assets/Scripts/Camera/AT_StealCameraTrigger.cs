using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AT_StealCameraTrigger : MonoBehaviour
{
    public Action<Collider> steal;

    private void OnTriggerEnter(Collider other)
    {
        steal(other);
    }
}
