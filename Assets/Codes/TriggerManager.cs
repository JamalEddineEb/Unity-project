using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerManager : MonoBehaviour
{
   public List<Checkpoint> checkpoints;
   
   public UIManager uiManager;
   public Canvas checkpointCanvas;
   public Button closeButton;
   public Animator turtleAnimator;
   
   public Animator freeKickMachineAnimation;
   
   

   void Start()
   {
        Debug.Log("Start");
        ListenCheckpoints(true);
        checkpointCanvas.enabled = false;
        freeKickMachineAnimation.SetBool("animate", false);
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

   public void CheckpointActivated(GameObject princesse, Checkpoint checkpoint)
   {
       if (checkpoints.Contains(checkpoint))
       {
            Debug.Log("checkpoint " + checkpoint.checkpointID);
            checkpointCanvas.enabled = true;
            uiManager.UpdateText("Checkpoint " + checkpoint.checkpointID);
            if(checkpoint.checkpointID.Equals("turtle")){
                turtleAnimator.SetBool("animate", true);
                Debug.Log("turtle animated");
            }

            if (checkpoint.checkpointID.Equals("freeKickMachine"))
            {
                freeKickMachineAnimation.SetBool("animate", true);
                Debug.Log("freeKickMachine animated");
                
            }
            
       }
   }
}