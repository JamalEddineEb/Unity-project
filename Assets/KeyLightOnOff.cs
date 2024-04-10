using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLightOnOff : MonoBehaviour
{
    private Light KeyLight;
    private int currentColorIndex = 0;
    private List<Color> colors = new List<Color>();

    void Start()
    {
        KeyLight = GetComponent<Light>();
        
        colors.Add(Color.white);
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            KeyLight.enabled = !KeyLight.enabled;
        }
        
        /////////////

        if (Input.GetKeyDown(KeyCode.X))
        {
            // Change light color
            currentColorIndex = (currentColorIndex + 1) % colors.Count; // Cycle through colors
            KeyLight.color = colors[currentColorIndex];
        }
    }
}