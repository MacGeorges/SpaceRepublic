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
        ThrustersManager.instance.ThrustersSlideRight((positionDelta.x < -0.00001), Mathf.Abs(positionDelta.x) * 100); //Left
        ThrustersManager.instance.ThrustersSlideLeft((positionDelta.x > 0.00001), Mathf.Abs(positionDelta.x) * 100); //Right
        ThrustersManager.instance.ThrustersSlideUp((positionDelta.y < -0.00001), Mathf.Abs(positionDelta.y) * 100); //Down
        ThrustersManager.instance.ThrustersSlideDown((positionDelta.y > 0.00001), Mathf.Abs(positionDelta.y) * 100); //Up
        ThrustersManager.instance.ThrustersForward((positionDelta.z < -0.00001), Mathf.Abs(positionDelta.z) * 100); //Backward
        ThrustersManager.instance.ThrustersBackward((positionDelta.z > 0.00001), Mathf.Abs(positionDelta.z) * 100); //Forward

        //if (positionDelta.x < -0.00001)
        //{
        //    Debug.Log("SlideLeft " + positionDelta.x);
        //    returnDirections.Add(Direction.SlideLeft);
        //}
        //if (positionDelta.x > 0.00001)
        //{
        //    Debug.Log("SlideRight " + positionDelta.x);
        //    returnDirections.Add(Direction.SlideRight);
        //}
        //if (positionDelta.y < -0.00001)
        //{
        //    Debug.Log("SlideDown " + positionDelta.y);
        //    returnDirections.Add(Direction.SlideDown);
        //}
        //if (positionDelta.y > 0.00001)
        //{
        //    Debug.Log("SlideUp " + positionDelta.y);
        //    returnDirections.Add(Direction.SlideUp);
        //}
        //if (positionDelta.z < -0.00001)
        //{
        //    Debug.Log("backward " + positionDelta.z);
        //    returnDirections.Add(Direction.backward);
        //}
        //if (positionDelta.z > 0.00001)
        //{
        //    Debug.Log("forward " + positionDelta.z);
        //    returnDirections.Add(Direction.forward);
        //}

        //rotation
        ThrustersManager.instance.ThrustersPinchDown((rotationDelta.x < -0.00001), Mathf.Abs(rotationDelta.x) * 100); //PinchUp
        ThrustersManager.instance.ThrustersPinchUp((rotationDelta.x > 0.00001), Mathf.Abs(rotationDelta.x) * 100); //PinchDown
        ThrustersManager.instance.ThrustersYawRight((rotationDelta.y < -0.00001), Mathf.Abs(rotationDelta.y) * 100); //YawLeft
        ThrustersManager.instance.ThrustersYawLeft((rotationDelta.y > 0.00001), Mathf.Abs(rotationDelta.y) * 100); //YawRight
        ThrustersManager.instance.ThrustersRollLeft((rotationDelta.z < -0.00001), Mathf.Abs(rotationDelta.z) * 100); //RollRight
        ThrustersManager.instance.ThrustersRollRight((rotationDelta.z > 0.00001), Mathf.Abs(rotationDelta.z) * 100); //RollLeft

        //if (rotationDelta.x < -0.00001)
        //{
        //    Debug.Log("PinchUp " + rotationDelta.x);
        //    returnDirections.Add(Direction.PinchUp);
        //}
        //if (rotationDelta.x > 0.00001)
        //{
        //    Debug.Log("PinchDown " + rotationDelta.x);
        //    returnDirections.Add(Direction.PinchDown);
        //}
        //if (rotationDelta.y < -0.00001)
        //{
        //    Debug.Log("YawLeft " + rotationDelta.y);
        //    returnDirections.Add(Direction.YawLeft);
        //}
        //if (rotationDelta.y > 0.00001)
        //{
        //    Debug.Log("YawRight " + rotationDelta.y);
        //    returnDirections.Add(Direction.YawRight);
        //}
        //if (rotationDelta.z < -0.00001)
        //{
        //    Debug.Log("RollRight " + rotationDelta.z);
        //    returnDirections.Add(Direction.RollRight);
        //}
        //if (rotationDelta.z > 0.00001)
        //{
        //    Debug.Log("RollLeft " + rotationDelta.z);
        //    returnDirections.Add(Direction.RollLeft);
        //}

        Debug.Log("==================================");

        return returnDirections;
    }

    private void Stabilize(List<Direction> directionsToCounter)
    {

    }
}
