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
        movement.Normalize();

        // Move the player
        this.transform.position += movement * 0.4f;

        // Rotate the player based on horizontal input
        if (horizontalAxis != 0)
        {
            float rotationAmount = horizontalAxis * 100f * Time.deltaTime;
            this.transform.Rotate(Vector3.up, rotationAmount);
        }

        // Set animator parameters
        this.anim.SetFloat("vertical", verticalAxis);
        this.anim.SetFloat("horizontal", horizontalAxis);
    }
}
