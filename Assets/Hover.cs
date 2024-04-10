using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;
    public Color hoverColor = Color.gray;
    private Color normalColor;

    void Start()
    {
        // Save the button's normal color
        normalColor = button.image.color;
    }

    // Called when mouse pointer enters the button's area
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Apply hover effect (e.g., change color)
        button.image.color = hoverColor;
    }

    // Called when mouse pointer exits the button's area
    public void OnPointerExit(PointerEventData eventData)
    {
        // Restore normal state (e.g., revert color to normal)
        button.image.color = normalColor;
    }
}
