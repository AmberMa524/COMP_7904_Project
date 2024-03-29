using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations;

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
        anim.SetBool("isWalking", false);
        if (am.sounds["Walk"].isPlaying)
            am.sounds["Walk"].Pause();
    }

    void FixedUpdate()
    {
        Vector2 mov = movement.ReadValue<Vector2>();

        if(mov == Vector2.zero) {
            anim.SetBool("isWalking", false);
        } else {
            anim.SetBool("isWalking", true);
        }

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (mov.x * rotationSpeed), transform.localEulerAngles.z);
        rb.velocity = Vector3.RotateTowards(rb.velocity, transform.forward, 4f, 0);

        rb.AddForce(transform.forward * mov.y * accelerationSpeed, ForceMode.VelocityChange);
        if (rb.velocity.magnitude > speedLimit)
            rb.velocity = rb.velocity.normalized * speedLimit;
        
        if (rb.velocity.magnitude < 0.3f)
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
