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

    public void AddActuator(Direction addingDirection)
    {
        if (!actuators.Contains(addingDirection))
        {
            actuators.Add(addingDirection);
            GetComponentInChildren<MeshRenderer>().material = thrusterFireMaterial;

            constantForceComponent.relativeForce = new Vector3(0, 0, -1 * thrusterForce);
        }
    }

    public void RemoveActuator(Direction removingDirection)
    {
        actuators.Remove(removingDirection);

        if(actuators.Count == 0)
        {
            GetComponentInChildren<MeshRenderer>().material = thrusterMaterial;
            constantForceComponent.relativeForce = Vector3.zero;
        }
    }
}
