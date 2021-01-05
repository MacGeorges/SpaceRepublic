using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipGyroscope : MonoBehaviour
{
    private Vector3 lastPosition;
    private Vector3 lastWorldPosition;
    private Vector3 lastRotation;

    public float stabilizationThreshold;

    public bool lockedMode;

    public static SpaceshipGyroscope instance;

    void Start()
    {
        instance = this;
        UpdateTranform();
    }

    void Update()
    {
        if (lockedMode)
        {
            Stabilize();
        }

        UpdateTranform();
    }

    public void ToggleLockedMode()
    {
        lockedMode = !lockedMode;

        if(!lockedMode)
        {
            ClearAllGyroscopeActuators();
        }
    }

    private void ClearAllGyroscopeActuators()
    {
        foreach(Thruster tmpThruster in ThrustersManager.instance.thrusters)
        {
            tmpThruster.actuators.RemoveAll(a => a.initiator == Initiator.Gyroscope);
        }
    }

    private void UpdateTranform()
    {
        lastPosition = transform.InverseTransformDirection(transform.position);
        lastWorldPosition = transform.position;
        lastRotation = transform.eulerAngles;
    }

    private void Stabilize()
    {
        Vector3 positionDelta = transform.InverseTransformDirection(transform.position) - lastPosition;
        Vector3 rotationDelta = transform.eulerAngles - lastRotation;

        //Debug.Log("positionDelta : " + positionDelta);
        //Debug.Log("rotationDelta : " + rotationDelta);

        //position
        if ((transform.position - lastWorldPosition) != Vector3.zero)
        {
            if(!SpaceshipControls.instance.leftButton)
                ThrustersManager.instance.ThrustersSlideRight(Initiator.Gyroscope, (positionDelta.x < -stabilizationThreshold), Mathf.Abs(positionDelta.x) * 10); //Left
            if (!SpaceshipControls.instance.rightButton)
                ThrustersManager.instance.ThrustersSlideLeft(Initiator.Gyroscope, (positionDelta.x > stabilizationThreshold), Mathf.Abs(positionDelta.x) * 10); //Right
            if (!SpaceshipControls.instance.downButton)
                ThrustersManager.instance.ThrustersSlideUp(Initiator.Gyroscope, (positionDelta.y < -stabilizationThreshold), Mathf.Abs(positionDelta.y) * 10); //Down
            if (!SpaceshipControls.instance.upButton)
                ThrustersManager.instance.ThrustersSlideDown(Initiator.Gyroscope, (positionDelta.y > stabilizationThreshold), Mathf.Abs(positionDelta.y) * 10); //Up
            if (!SpaceshipControls.instance.backwarddButton)
                ThrustersManager.instance.ThrustersForward(Initiator.Gyroscope, (positionDelta.z < -stabilizationThreshold), Mathf.Abs(positionDelta.z) * 10); //Backward
            if (!SpaceshipControls.instance.forwardButton)
                ThrustersManager.instance.ThrustersBackward(Initiator.Gyroscope, (positionDelta.z > stabilizationThreshold), Mathf.Abs(positionDelta.z) * 10); //Forward
        }

        //rotation
        if (!SpaceshipControls.instance.pinchDown)
            ThrustersManager.instance.ThrustersPinchDown(Initiator.Gyroscope, (rotationDelta.x < -stabilizationThreshold), Mathf.Abs(rotationDelta.x) * 10); //PinchUp
        if (!SpaceshipControls.instance.pinchUp)
        {

            ThrustersManager.instance.ThrustersPinchUp(Initiator.Gyroscope, (rotationDelta.x > stabilizationThreshold), Mathf.Abs(rotationDelta.x) * 10); //PinchDown
        }
        if (!SpaceshipControls.instance.yawRight)
            ThrustersManager.instance.ThrustersYawRight(Initiator.Gyroscope, (rotationDelta.y < -stabilizationThreshold), Mathf.Abs(rotationDelta.y) * 10); //YawLeft
        if (!SpaceshipControls.instance.yawLeft)
            ThrustersManager.instance.ThrustersYawLeft(Initiator.Gyroscope, (rotationDelta.y > stabilizationThreshold), Mathf.Abs(rotationDelta.y) * 10); //YawRight
        if (!SpaceshipControls.instance.rollLeftButton)
            ThrustersManager.instance.ThrustersRollLeft(Initiator.Gyroscope, (rotationDelta.z < -stabilizationThreshold), Mathf.Abs(rotationDelta.z) * 10); //RollRight
        if (!SpaceshipControls.instance.rollRightButton)
            ThrustersManager.instance.ThrustersRollRight(Initiator.Gyroscope, (rotationDelta.z > stabilizationThreshold), Mathf.Abs(rotationDelta.z) * 10); //RollLeft
    }
}
