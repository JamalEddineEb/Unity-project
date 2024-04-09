using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Playerrank 
{
    public CarIdentity identity;
    public int lapNumber = 1;
    public int lastCheckpoint = 0;
    public bool hasFinished = false;
    public int rank = -1;

    public Playerrank(CarIdentity carIdentity)
    {
        this.identity = carIdentity;
    }
}