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

    void Awake()
    {
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

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + (mov.x * 2f), transform.localEulerAngles.z);
        rb.velocity = Vector3.RotateTowards(rb.velocity, transform.forward, 4f, 0);

        rb.AddForce(transform.forward * mov.y, ForceMode.VelocityChange);
        if (rb.velocity.magnitude > speedLimit)
            rb.velocity = rb.velocity.normalized * speedLimit;
    }
}
