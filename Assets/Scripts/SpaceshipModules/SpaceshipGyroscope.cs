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

        Debug.Log("positionDelta : " + positionDelta);
        Debug.Log("rotationDelta : " + rotationDelta);

        //position
        if ((transform.position - lastWorldPosition) != Vector3.zero)
        {
            Debug.Log("World Movement");
            if(!SpaceshipControls.instance.leftButton)
                ThrustersManager.instance.ThrustersSlideRight((positionDelta.x < -stabilizationThreshold), Mathf.Abs(positionDelta.x) * 10); //Left
            if (!SpaceshipControls.instance.rightButton)
                ThrustersManager.instance.ThrustersSlideLeft((positionDelta.x > stabilizationThreshold), Mathf.Abs(positionDelta.x) * 10); //Right
            if (!SpaceshipControls.instance.downButton)
                ThrustersManager.instance.ThrustersSlideUp((positionDelta.y < -stabilizationThreshold), Mathf.Abs(positionDelta.y) * 10); //Down
            if (!SpaceshipControls.instance.upButton)
                ThrustersManager.instance.ThrustersSlideDown((positionDelta.y > stabilizationThreshold), Mathf.Abs(positionDelta.y) * 10); //Up
            if (!SpaceshipControls.instance.backwarddButton)
                ThrustersManager.instance.ThrustersForward((positionDelta.z < -stabilizationThreshold), Mathf.Abs(positionDelta.z) * 10); //Backward
            if (!SpaceshipControls.instance.forwardButton)
                ThrustersManager.instance.ThrustersBackward((positionDelta.z > stabilizationThreshold), Mathf.Abs(positionDelta.z) * 10); //Forward
        }

        //rotation
        if (!SpaceshipControls.instance.pinchDown)
            ThrustersManager.instance.ThrustersPinchDown((rotationDelta.x < -stabilizationThreshold), Mathf.Abs(rotationDelta.x) * 10); //PinchUp
        if (!SpaceshipControls.instance.pinchUp)
        {
            Debug.Log("pinchDown stabilized");

            ThrustersManager.instance.ThrustersPinchUp((rotationDelta.x > stabilizationThreshold), Mathf.Abs(rotationDelta.x) * 10); //PinchDown
        }
        else
        {
            Debug.Log("pinchDown not stabilized");
        }
        if (!SpaceshipControls.instance.yawRight)
            ThrustersManager.instance.ThrustersYawRight((rotationDelta.y < -stabilizationThreshold), Mathf.Abs(rotationDelta.y) * 10); //YawLeft
        if (!SpaceshipControls.instance.yawLeft)
            ThrustersManager.instance.ThrustersYawLeft((rotationDelta.y > stabilizationThreshold), Mathf.Abs(rotationDelta.y) * 10); //YawRight
        if (!SpaceshipControls.instance.rollLeftButton)
            ThrustersManager.instance.ThrustersRollLeft((rotationDelta.z < -stabilizationThreshold), Mathf.Abs(rotationDelta.z) * 10); //RollRight
        if (!SpaceshipControls.instance.rollRightButton)
            ThrustersManager.instance.ThrustersRollRight((rotationDelta.z > stabilizationThreshold), Mathf.Abs(rotationDelta.z) * 10); //RollLeft
    }
}
