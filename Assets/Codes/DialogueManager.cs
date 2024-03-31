using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public List<DialogueTrigger> dialogueTriggers;

    // Start is called before the first frame update
    void Start()
    {
        // Find all DialogueTrigger components in the scene and add them to the dialogueTriggers list
        dialogueTriggers.AddRange(FindObjectsOfType<DialogueTrigger>());
        
        // Start listening to the dialogue triggers
        ListenDialogueTriggers(true);
    }
    
    private void ListenDialogueTriggers(bool subscribe)
    {
        foreach (DialogueTrigger dialogueTrigger in dialogueTriggers)
        {
            if (subscribe) 
                dialogueTrigger.onCheckpointEnter.AddListener(OnCheckpointEnter);
            else 
                dialogueTrigger.onCheckpointEnter.RemoveListener(OnCheckpointEnter);
        }
    }
    
    private void OnCheckpointEnter(GameObject player, DialogueTrigger dialogueTrigger)
    {
        Debug.Log("Checkpoint reached");
    }
}