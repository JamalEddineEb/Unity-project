using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerManager : MonoBehaviour
{
   public List<Checkpoint> checkpoints;
   
   public UIManager uiManager;
   public Canvas checkpointCanvas;
   public Button closeButton;
   

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

   public void CheckpointActivated(GameObject princesse, Checkpoint checkpoint)
   {
       if (checkpoints.Contains(checkpoint))
       {
            Debug.Log("checkpoint " + checkpoint.checkpointID);
            checkpointCanvas.enabled = true;
            uiManager.UpdateText("Checkpoint " + checkpoint.checkpointID);
            
       }
   }
}