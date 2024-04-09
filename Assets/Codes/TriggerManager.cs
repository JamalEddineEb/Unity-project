using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TriggerManager : MonoBehaviour
{
   public List<Checkpoint> checkpoints;
   
   public UIManager uiManager;
   public Canvas checkpointCanvas;
   public Button closeButton;
   public Animator turtleAnimator;
   public Animator freeKickMachineAnimation;
   public Animator rocketAnimator;
   public Button raceButton;

   
   

   void Start()
   {
        Debug.Log("Start");
        ListenCheckpoints(true);
        checkpointCanvas.enabled = false;
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(HideCanvas);
        }
        else
        {
            Debug.LogWarning("Close Button not assigned in TriggerManager!");
        }
        
   }
   
   void HideCanvas()
   {
       checkpointCanvas.enabled = false;
   }

   private void ListenCheckpoints(bool subscribe)
   {

       foreach (Checkpoint checkpoint in checkpoints)
       {
           if (subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
           else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
       }
   }
   
   void CarButtonClicked()
   {
       Debug.Log("Car Button Clicked and we move to planet 2");
       SceneManager.LoadScene("PrincessFile");
       
   }

   public void CheckpointActivated(GameObject princesse, Checkpoint checkpoint)
   {
       raceButton.gameObject.SetActive(false);
       if (checkpoints.Contains(checkpoint))
       {
            Debug.Log("checkpoint " + checkpoint.checkpointID);
            if(checkpoint.checkpointID.Equals("turtle")){
                turtleAnimator.SetBool("animate", true);
                checkpointCanvas.enabled = true;
                uiManager.UpdateText(
                    "Turtles, gentle wanderers of the wild, embody the harmony of nature's rhythm. Their slow, deliberate movements echo the tranquil cadence of the natural world.\nJamal Eddine El Betoui");
                Debug.Log("turtle animated");
            }

            if (checkpoint.checkpointID.Equals("freeKickMachine"))
            {
                freeKickMachineAnimation.SetBool("animate", true);
                checkpointCanvas.enabled = true;
                uiManager.UpdateText(
                    "The free-kick machine, a marvel of precision and power, channels the essence of football's artistry. With a single strike, it weaves moments of brilliance into the fabric of the game.\nSaad Beidouri");
                Debug.Log("freeKickMachine animated");
                
            }

            if (checkpoint.checkpointID.Equals("Rocket"))
            {
                rocketAnimator.SetBool("animate", true);
                checkpointCanvas.enabled = true;
                uiManager.UpdateText(
                    "The rocket, a symbol of human ingenuity and ambition, soars through the heavens with grace and power.\nLamia Baidouri");
                Debug.Log("Rocket animated");
            }

            if (checkpoint.checkpointID.Equals("Car"))
            {
                checkpointCanvas.enabled = true;
                uiManager.UpdateText(
                    "Cars and races, a fusion of adrenaline and engineering mastery, epitomize the pinnacle of speed and skill. They ignite our senses, propelling us into a world where split-second decisions define victory or defeat.\nThe Group");
                raceButton.gameObject.SetActive(true);
                raceButton.onClick.AddListener(CarButtonClicked);

            }
            
       }
   }
}