using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLightOnOff : MonoBehaviour
{
    private Light backLight;
    private int currentColorIndex = 0;
    private List<Color> colors = new List<Color>();

    void Start()
    {
        backLight = GetComponent<Light>();
        
        colors.Add(Color.white);
        colors.Add(Color.red);
        colors.Add(Color.green);
        colors.Add(Color.blue);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            backLight.enabled = !backLight.enabled;
        }
        
        /////////////

        if (Input.GetKeyDown(KeyCode.V))
        {
            // Change light color
            currentColorIndex = (currentColorIndex + 1) % colors.Count; // Cycle through colors
            backLight.color = colors[currentColorIndex];
        }
    }
}
