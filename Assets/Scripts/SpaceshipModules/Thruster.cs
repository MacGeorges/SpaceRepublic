using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
    public ThrusterType thrusterType;

    public List<Position> thrusterPositions;

    public float thrusterForce;

    public Material thrusterMaterial;
    public Material thrusterFireMaterial;

    public ConstantForce constantForceComponent;

    [SerializeField]
    private List<Actuator> actuators;

    private void Start()
    {
        actuators = new List<Actuator>();
    }

    public void AddActuator(Actuator addingActuator)
    {
        if (!actuators.Contains(addingActuator))
        {
            actuators.Add(addingActuator);
            GetComponentInChildren<MeshRenderer>().material = thrusterFireMaterial;
        }
    }

    public void RemoveActuator(Actuator removingActuator)
    {
        actuators.RemoveAll(a => a.direction == removingActuator.direction);

        if(actuators.Count == 0)
        {
            GetComponentInChildren<MeshRenderer>().material = thrusterMaterial;
            constantForceComponent.relativeForce = Vector3.zero;
        }
    }

    private void Update()
    {
        constantForceComponent.relativeForce = new Vector3(0, 0,
            -1 * thrusterForce * GetForce() * SpaceshipControls.instance.speedLimit);

    }

    private float GetForce()
    {
        float returnForce = 0f;

        foreach (Actuator tmpAct in actuators)
        {
            returnForce += tmpAct.force;
        }

        if (returnForce > thrusterForce) { returnForce = thrusterForce; }

        return returnForce;
    }
}
