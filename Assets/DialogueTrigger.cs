using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public UnityEvent<GameObject, DialogueTrigger> onCheckpointEnter;

    void OnTriggerEnter(Collider collider)
    {
        // if entering object is tagged as the Player
        if (collider.gameObject.CompareTag("Player"))
        {
            onCheckpointEnter.Invoke(collider.gameObject, this);
            Debug.Log("Checkpoint reached");
        }
    }
}