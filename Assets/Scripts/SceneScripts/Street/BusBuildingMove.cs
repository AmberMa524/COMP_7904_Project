using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusBuildingMove : MonoBehaviour
{
    public GameObject streetSet1;
    public GameObject streetSet2;
    public float speed = 10f;

    private void Update()
    {
        streetSet1.transform.position = new Vector3(streetSet1.transform.position.x, streetSet1.transform.position.y, streetSet1.transform.position.z + (speed * Time.deltaTime));
        streetSet2.transform.position = new Vector3(streetSet2.transform.position.x, streetSet2.transform.position.y, streetSet2.transform.position.z + (speed * Time.deltaTime));

        if(streetSet1.transform.position.z > 104)
        {
            streetSet1.transform.position = new Vector3(streetSet2.transform.position.x, streetSet2.transform.position.y, streetSet2.transform.position.z - 80);
        }
        if (streetSet2.transform.position.z > 104)
        {
            streetSet2.transform.position = new Vector3(streetSet1.transform.position.x, streetSet1.transform.position.y, streetSet1.transform.position.z - 80);
        }
    }
}
