using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipGyroscope : MonoBehaviour
{
    private Vector3 lastPosition;
    private Vector3 lastRotation;

    public bool lockedMode;

    public static SpaceshipGyroscope instance;

    void Start()
    {
        instance = this;
        UpdateTranform();
    }

    void Update()
    {
        if(lockedMode)
        {
            Stabilize(RecognizeMovements());
        }

        UpdateTranform();
    }


    private void UpdateTranform()
    {
        lastPosition = transform.InverseTransformDirection(transform.position);
        lastRotation = transform.eulerAngles;
    }

    private List<Direction> RecognizeMovements()
    {
        Vector3 positionDelta = transform.InverseTransformDirection(transform.position) - lastPosition;
        Vector3 rotationDelta = transform.eulerAngles - lastRotation;

        Debug.Log("positionDelta : " + positionDelta);
        Debug.Log("rotationDelta : " + rotationDelta);

        List<Direction> returnDirections = new List<Direction>();

        //position
        if (positionDelta.x < -0.00001)
        {
            Debug.Log("SlideLeft " + positionDelta.x);
            returnDirections.Add(Direction.SlideLeft);
        }
        if (positionDelta.x > 0.00001)
        {
            Debug.Log("SlideRight " + positionDelta.x);
            returnDirections.Add(Direction.SlideRight);
        }
        if (positionDelta.y < -0.00001)
        {
            Debug.Log("SlideDown " + positionDelta.y);
            returnDirections.Add(Direction.SlideDown);
        }
        if (positionDelta.y > 0.00001)
        {
            Debug.Log("SlideUp " + positionDelta.y);
            returnDirections.Add(Direction.SlideUp);
        }
        if (positionDelta.z < -0.00001)
        {
            Debug.Log("backward " + positionDelta.z);
            returnDirections.Add(Direction.backward);
        }
        if (positionDelta.z > 0.00001)
        {
            Debug.Log("forward " + positionDelta.z);
            returnDirections.Add(Direction.forward);
        }

        //rotation
        if (rotationDelta.x < -0.00001)
        {
            Debug.Log("PinchUp " + rotationDelta.x);
            returnDirections.Add(Direction.PinchUp);
        }
        if (rotationDelta.x > 0.00001)
        {
            Debug.Log("PinchDown " + rotationDelta.x);
            returnDirections.Add(Direction.PinchDown);
        }
        if (rotationDelta.y < -0.00001)
        {
            Debug.Log("YawLeft " + rotationDelta.y);
            returnDirections.Add(Direction.YawLeft);
        }
        if (rotationDelta.y > 0.00001)
        {
            Debug.Log("YawRight " + rotationDelta.y);
            returnDirections.Add(Direction.YawRight);
        }
        if (rotationDelta.z < -0.00001)
        {
            Debug.Log("RollRight " + rotationDelta.z);
            returnDirections.Add(Direction.RollRight);
        }
        if (rotationDelta.z > 0.00001)
        {
            Debug.Log("RollLeft " + rotationDelta.z);
            returnDirections.Add(Direction.RollLeft);
        }

        Debug.Log("==================================");

        return returnDirections;
    }

    private void Stabilize(List<Direction> directionsToCounter)
    {

    }
}
