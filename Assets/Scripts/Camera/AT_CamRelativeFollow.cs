using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_CamRelativeFollow : MonoBehaviour
{
    public Vector3 followPosition;
    public Transform target;

    private void Update()
    {
        transform.position = target.position + followPosition;
        transform.LookAt(target);
    }
}
