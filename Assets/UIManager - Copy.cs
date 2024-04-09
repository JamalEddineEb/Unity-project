using TMPro;
using UnityEngine;

public class Planet1UIManager : MonoBehaviour
{
    public TextMeshProUGUI lapText;

    public void UpdateLapText(string message)
    {
        lapText.text = message;
    }
}
