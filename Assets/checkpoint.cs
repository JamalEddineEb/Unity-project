using System.Collections.Generic;
using UnityEngine;
using System;


public class checkpoint : MonoBehaviour
{
    private List<Action<CarIdentity, checkpoint>> listeners = new List<Action<CarIdentity, checkpoint>>();

    public void Subscribe(Action<CarIdentity, checkpoint> listener)
    {
        listeners.Add(listener);
    }

    public void Unsubscribe(Action<CarIdentity, checkpoint> listener)
    {
        listeners.Remove(listener);
    }

    void OnTriggerEnter(Collider other)
    {
        CarIdentity carIdentity = other.GetComponent<CarIdentity>();
        if (carIdentity != null)
        {
            foreach (var listener in listeners)
            {
                listener.Invoke(carIdentity, this);
            }
        }
    }
}
