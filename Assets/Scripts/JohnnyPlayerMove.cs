using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEditor.Animations;

public class JohnnyPlayerMove : MonoBehaviour
{
    InputActions ia;
    InputAction movement;
    public Rigidbody rb;
    public float speedLimit = 2f;
    public float accelerationSpeed = 0.3f;
    public float rotationSpeed = 2.5f;

    private Animator anim;
    private AudioManager am;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        am = GetComponent<AudioManager>();
        ia = new InputActions();
        movement = ia.Player.Movement;
    }

    private void OnEnable()
    {
        movement.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
    }

    void FixedUpdate()
    {
        Vector2 mov = movement.ReadValue<Vector2>();

        if(mov == Vector2.zero) {
            anim.SetBool("isWalking", false);
            Debug.Log("bruh");
            if (am.sounds["Walk"].isPlaying)
                am.sounds["Walk"].Pause();
        } else {
            anim.SetBool("isWalking", true);
            Debug.Log("bruh1231234");
            if (!am.sounds["Walk"].isPlaying)
                am.sounds["Walk"].Play();
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (mov.x * rotationSpeed), transform.localEulerAngles.z);
        rb.velocity = Vector3.RotateTowards(rb.velocity, transform.forward, 4f, 0);

        rb.AddForce(transform.forward * mov.y*5, ForceMode.VelocityChange);
        if (rb.velocity.magnitude > speedLimit)
            rb.velocity = rb.velocity.normalized * speedLimit;
        
        if (rb.velocity.magnitude < 1.0f)
        {
            if (am.sounds["Walk"].isPlaying)
                am.sounds["Walk"].Pause();
        }
        else
        {
            if (!am.sounds["Walk"].isPlaying)
                am.sounds["Walk"].Play();
        }
    }
}
