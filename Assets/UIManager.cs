using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;


    public void UpdateText(string message)
    {
        textMeshProUGUI.text = message;
    }
}