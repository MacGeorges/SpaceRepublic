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

    [SerializeField]
    private bool boosting;

    [SerializeField]
    private List<Actuator> actuators;

    private void Start()
    {
        actuators = new List<Actuator>();
    }

    public void AddActuator(Actuator addingActuator)
    {
        if (actuators.FindAll(a => a.direction == addingActuator.direction).Count == 0)//!actuators.Contains(addingActuator))
        {
            if (debug)
                Debug.Log("Add Actuator " + addingActuator.direction);

            actuators.Add(addingActuator);
            GetComponentInChildren<MeshRenderer>().material = thrusterFireMaterial;
        }
    }

    public void RemoveActuator(Actuator removingActuator)
    {
        if (debug)
        {
            Debug.Log("Remove Actuator " + removingActuator.direction);
            Debug.Log("Remaining Actuators " + actuators.Count);
        }

        actuators.RemoveAll(a => a.direction == removingActuator.direction);

        if(actuators.Count == 0)
        {
            GetComponentInChildren<MeshRenderer>().material = thrusterMaterial;
            constantForceComponent.relativeForce = Vector3.zero;
        }
    }

    void Update()
    {
        constantForceComponent.relativeForce = new Vector3(0, 0,
            -1 * thrusterForce * GetForce() * SpaceshipControls.instance.speedLimit);

        if (debug)
        {
            Debug.Log("force : " + GetForce());
            Debug.Log("Thruster force : " + -1 * thrusterForce * GetForce() * SpaceshipControls.instance.speedLimit);
            Debug.Log("=========================================");
        }

        //debugText.text = constantForceComponent.relativeForce.z.ToString("F2");

        //float tmpScale = Mathf.Clamp(1 + Mathf.Abs(constantForceComponent.relativeForce.z), 1, 2);
        //transform.localScale = new Vector3 (tmpScale, tmpScale, tmpScale);

    }

    private float GetForce()
    {
        if (debug)
            Debug.Log("Nb of Actuators " + actuators.Count);

        float returnForce = 0f;
        bool tmpBoost = false;

        foreach (Actuator tmpAct in actuators)
        {
            returnForce += tmpAct.force;
            if (tmpAct.boost)
                tmpBoost = true;
        }

        boosting = tmpBoost;

        if (boosting)
        {
            if (returnForce > thrusterBoostForce) { returnForce = thrusterBoostForce; }
        }
        else
        {
            if (returnForce > thrusterForce) { returnForce = thrusterForce; }
        }

        //if (actuators.Count > 0)
        //{
        //    returnForce = 1;
        //}

        return returnForce;
    }
}
