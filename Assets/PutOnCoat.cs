using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnCoat : MonoBehaviour
{
    public GameObject withCoat;
    public GameObject withoutCoat;

    public Avatar withCoatAvatar;

    public void activateCoat() {
        withoutCoat.SetActive(false);
        withCoat.SetActive(true);
        gameObject.GetComponent<Animator>().avatar = withCoatAvatar;
    }
}
