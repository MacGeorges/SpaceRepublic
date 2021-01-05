using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Initiator { User, Gyroscope}

public class Actuator
{
    public Initiator initiator;
    public Direction direction;
    public float force;

    public Actuator(Initiator newInitiator, Direction newDirection, float newForce)
    {
        initiator = newInitiator;
        direction = newDirection;
        force = newForce;
    }
}
