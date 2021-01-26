using System.Collections;
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
        Actuator tmpAct = actuators.Find(a => a.direction == addingActuator.direction);
        if (tmpAct == null)
        {
            actuators.Add(addingActuator);
        }
        else
        {
            tmpAct.force = addingActuator.force;
        }

        return;

        if (actuators.FindAll(a => a.direction == addingActuator.direction).Count == 0)
        {
            actuators.Add(addingActuator);
        }
    }

    public void RemoveActuator(Actuator removingActuator)
    {
        actuators.RemoveAll(a => a.direction == removingActuator.direction && a.initiator == removingActuator.initiator);
    }

    void Update()
    {
        if(debug)
        {
            Debug.Log(name + " actuators : " + actuators.Count);
        }

        if (actuators.Count == 0)
        {
            GetComponentInChildren<MeshRenderer>().material = thrusterMaterial;
            constantForceComponent.relativeForce = Vector3.zero;
        }
        else
        {
            GetComponentInChildren<MeshRenderer>().material = thrusterFireMaterial;
            constantForceComponent.relativeForce = new Vector3(0, 0, -GetForce());
        }
    }

    private float GetForce()
    {
        float returnForce = 0f;

        foreach (Actuator tmpAct in actuators)
        {
            returnForce += tmpAct.force;
        }

        returnForce *= thrusterForce;

        returnForce = Mathf.Clamp(returnForce, 0, thrusterForce);

        if(debug)
        {
            Debug.Log("return force : " + returnForce);
        }

        return returnForce;
    }
}
