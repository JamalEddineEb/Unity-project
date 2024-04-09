using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine;
using UnityEngine.Events;

public class PlayerControls : MonoBehaviour
{
    private Vector2 input;
    public UnityEvent<Vector2> onInput;

    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        input = new Vector2(inputX, inputY).normalized;
        onInput.Invoke(input);
    }
}
