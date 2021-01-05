﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thruster : MonoBehaviour
{
    public ThrusterType thrusterType;

    public List<Position> thrusterPositions;

    public float thrusterForce;
    public float thrusterBoostForce;

    public Material thrusterMaterial;
    public Material thrusterFireMaterial;

    public ConstantForce constantForceComponent;

    public Text debugText;

    public bool debug;

    public List<Actuator> actuators;

    //Debug
    public int nbActuators;

    private void Start()
    {
        actuators = new List<Actuator>();
    }

    public void AddActuator(Actuator addingActuator)
    {
        if (actuators.FindAll(a => a.direction == addingActuator.direction).Count == 0)//!actuators.Contains(addingActuator))
        {
            actuators.Add(addingActuator);
            GetComponentInChildren<MeshRenderer>().material = thrusterFireMaterial;
        }
    }

    public void RemoveActuator(Actuator removingActuator)
    {
        actuators.RemoveAll(a => a.direction == removingActuator.direction);

        if (actuators.Count == 0)
        {
            GetComponentInChildren<MeshRenderer>().material = thrusterMaterial;
            constantForceComponent.relativeForce = Vector3.zero;
        }
    }

    void Update()
    {
        nbActuators = actuators.Count;

        //constantForceComponent.relativeForce = new Vector3(0, 0,
        //    -1 * thrusterForce * GetForce() * SpaceshipControls.instance.speedLimit);

        constantForceComponent.relativeForce = new Vector3(0, 0, -1 * GetForce());

        if (debug)
        {
            Debug.Log("force : " + GetForce());
            Debug.Log("Thruster force : " + constantForceComponent.relativeForce.z);
            Debug.Log("=========================================");
        }

        //debugText.text = constantForceComponent.relativeForce.z.ToString("F2");

        //float tmpScale = Mathf.Clamp(1 + Mathf.Abs(constantForceComponent.relativeForce.z), 1, 2);
        //transform.localScale = new Vector3 (tmpScale, tmpScale, tmpScale);

    }

    private float GetForce()
    {
        float returnForce = 0f;

        foreach (Actuator tmpAct in actuators)
        {
            returnForce += tmpAct.force;
        }

        if (SpaceshipControls.instance.boost)
        {
            returnForce = thrusterBoostForce;
        }
        else
        {
            if (returnForce > thrusterForce) { returnForce = thrusterForce; }
        }

        return returnForce;
    }
}