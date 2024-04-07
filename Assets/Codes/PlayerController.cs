using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    private LayerMask layerMask;
    
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        // Calculate movement
        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        rb.MovePosition(rb.position + movement * 0.4f);

        // Move the player
        this.transform.position += movement * 0.2f;

        // Rotate the player based on horizontal input
        if (horizontalAxis != 0)
        {
            float rotationAmount = horizontalAxis * 50f * Time.fixedDeltaTime;
            Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotationAmount);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        // Set animator parameters
        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);
    }
}
