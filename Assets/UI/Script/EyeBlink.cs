using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeBlink : MonoBehaviour
{

    private int blink_value;

    private bool blinked;

    private int alpha_value;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        blink_value = Random.Range(1, 3);
        image = gameObject.GetComponent<Image>();
        blinked = false;
        alpha_value = 0;
        image.color = new Color(image.color.r, image.color.g, image.color.b, (float)alpha_value);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(blink_value);
        if (blink_value == 1)
        {
            if (blinked)
            {
                unblink();
            }
            else {
                blink();
            }
        }
        else {
            blink_value = Random.Range(1, 3);
        }
    }

    private void blink() {

        alpha_value += 17;
        image.color = new Color(image.color.r, image.color.g, image.color.b, (float)alpha_value);
        if (alpha_value >= 255) {
            blinked = true;
        }
        //image.CrossFadeAlpha(1, 2f, false);

    }

    private void unblink() {

        alpha_value -= 17;
        image.color = new Color(image.color.r, image.color.g, image.color.b, (float)alpha_value);
        if (alpha_value <= 0)
        {
            blinked = false;
            blink_value = Random.Range(1, 3);
        }
        //blink_value = Random.Range(1, 3);
        //image.CrossFadeAlpha(0, 2f, false);
    }
}
