using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillLightOnOff : MonoBehaviour
{
    private Light FillLight;
    private int currentColorIndex = 0;
    private List<Color> colors = new List<Color>();

    void Start()
    {
        FillLight = GetComponent<Light>();
        
        colors.Add(Color.white);
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FillLight.enabled = !FillLight.enabled;
        }
        
        /////////////

        if (Input.GetKeyDown(KeyCode.C))
        {
            // Change light color
            currentColorIndex = (currentColorIndex + 1) % colors.Count; // Cycle through colors
            FillLight.color = colors[currentColorIndex];
        }
    }
}
