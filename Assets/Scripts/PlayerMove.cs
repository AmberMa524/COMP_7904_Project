using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    InputActions ia;
    InputAction movement;
    public Rigidbody rb;
    public float speedLimit = 2f;
    public float accelerationSpeed = 0.3f;
    public float rotationSpeed = 2.5f;
    private AudioManager audioManager;

    void Awake()
    {
        ia = new InputActions();
        movement = ia.Player.Movement;
        audioManager = GetComponent<AudioManager>();
        audioManager.sounds["Walk"].loop = true;
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

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (mov.x * rotationSpeed), transform.localEulerAngles.z);
        rb.velocity = Vector3.RotateTowards(rb.velocity, transform.forward, 4f, 0);

        rb.AddForce(transform.forward * mov.y, ForceMode.VelocityChange);
        if (rb.velocity.magnitude > speedLimit)
            rb.velocity = rb.velocity.normalized * speedLimit;

        if (rb.velocity.magnitude < 1.0f)
        {
            if (audioManager.sounds["Walk"].isPlaying)
                audioManager.sounds["Walk"].Pause();
        }
        else
        {
            if (!audioManager.sounds["Walk"].isPlaying)
                audioManager.sounds["Walk"].Play();
        }
    }
}
