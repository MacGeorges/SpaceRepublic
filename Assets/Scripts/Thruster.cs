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
    private List<Direction> actuators;

    public void AddActuator(Actuator addingActuator)
    {
        if (!actuators.Contains(addingActuator.direction))
        {
            actuators.Add(addingActuator.direction);
            GetComponentInChildren<MeshRenderer>().material = thrusterFireMaterial;

            constantForceComponent.relativeForce = new Vector3(0, 0, -1 * thrusterForce * addingActuator.force);
        }
    }

    public void RemoveActuator(Actuator removingActuator)
    {
        actuators.Remove(removingActuator.direction);

        if(actuators.Count == 0)
        {
            GetComponentInChildren<MeshRenderer>().material = thrusterMaterial;
            constantForceComponent.relativeForce = Vector3.zero;
        }
    }
}
