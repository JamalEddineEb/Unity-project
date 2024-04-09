using System.Collections;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public PlayerControls playerControls;
    public AIControls[] aiControls;
    public LapManager lapTracker;
    public TricolorLights tricolorLights;

    // New audio references
    public AudioSource audioSource;
    public AudioClip lowBeep;
    public AudioClip highBeep;

    // Existing methods
    void Awake()
    {
        StartGame();
    }
    public void StartGame()
    {
        FreezePlayers(true);
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        tricolorLights.SetProgress(1);
        if (lowBeep != null)
        {
            audioSource.PlayOneShot(lowBeep);
        }
        else
        {
            Debug.LogWarning("Low beep audio clip is not assigned in GameManager.");
        }

        yield return new WaitForSeconds(1);
        Debug.Log("2");
        tricolorLights.SetProgress(2);
        if (lowBeep != null)
        {
            audioSource.PlayOneShot(lowBeep);
        }
        else
        {
            Debug.LogWarning("Low beep audio clip is not assigned in GameManager.");
        }

        yield return new WaitForSeconds(1);
        Debug.Log("1");
        tricolorLights.SetProgress(3);
        if (lowBeep != null)
        {
            audioSource.PlayOneShot(lowBeep);
        }
        else
        {
            Debug.LogWarning("Low beep audio clip is not assigned in GameManager.");
        }

        yield return new WaitForSeconds(1);
        Debug.Log("GO");
        tricolorLights.SetProgress(4);
        if (highBeep != null)
        {
            audioSource.PlayOneShot(highBeep);
        }
        else
        {
            Debug.LogWarning("High beep audio clip is not assigned in GameManager.");
        }

        StartRacing();
        yield return new WaitForSeconds(2f);
        tricolorLights.SetAllLightsOff();
    }


    public void StartRacing()
    {
        FreezePlayers(false);
    }
    void FreezePlayers(bool freeze)
    {
        // Check if the aiControls array is not null and has elements
        if (aiControls != null)
        {
            // Loop through each AI and disable or enable its controls
            foreach (var aiControl in aiControls)
            {
                if (aiControl != null)
                {
                    aiControl.enabled = !freeze;
                }
                else
                {
                    Debug.LogError("An element of aiControls is not set in GameManager");
                }
            }
        }
        else
        {
            Debug.LogError("aiControls array is not set in GameManager");
        }
        if (playerControls != null)
        {
            playerControls.enabled = !freeze;
        }
        else
        {
            Debug.LogError("playerControls is not set in GameManager");
        }
    }

}

