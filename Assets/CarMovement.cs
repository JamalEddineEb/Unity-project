using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Rigidbody rg;
    public float forwardMoveSpeed;
    public float backwardMoveSpeed;
    public float steerSpeed;
    private Vector2 input;

    public void setInputs(Vector2 newInput)
    {
        input = newInput;
    }

    void FixedUpdate()
    {
        float speed = input.y > 0 ? forwardMoveSpeed : backwardMoveSpeed;
        if (input.y == 0) speed = 0;
        rg.AddForce(transform.forward * speed, ForceMode.Acceleration);

        float rotation = input.x * steerSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0, Space.World);
    }
}
