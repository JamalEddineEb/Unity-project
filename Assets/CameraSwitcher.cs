using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; 
    private int currentCameraIndex = 0;

    void Start()
    {
        // Disable all cameras except the first one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check for input to switch between cameras
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Switching camera");
            // Disable the current camera
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Move to the next camera (looping back to the first if at the end)
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Enable the new current camera
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }
    }
}