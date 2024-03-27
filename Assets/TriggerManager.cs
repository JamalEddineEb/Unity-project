using System.Collections.Generic;
using UnityEngine;
public class TriggerManager : MonoBehaviour
{
   public List<Checkpoint> checkpoints;

   void Start()
   {
        Debug.Log("Start");
        ListenCheckpoints(true);
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

       // Do we know this checkpoint ?
       if (checkpoints.Contains(checkpoint))
       {
            Debug.Log("checkpoint " + checkpoint.checkpointID);
       }
   }
}