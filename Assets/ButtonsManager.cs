using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public Button StartButton;

    void Start()
    {
        // Add listener for button click event
        StartButton.onClick.AddListener(HandleButtonClick);
    }

    // Method to handle button click
    public void HandleButtonClick()
    {
        // Load the game scene
        SceneManager.LoadScene("SampleScene");
    }
}
