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

    private Rigidbody rb;

    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Debug.Log("Local Velocity : " + transform.InverseTransformDirection(rb.velocity).x);

        if (lockedMode)
        {
            Stabilize();
        }
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

    private void Stabilize()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(rb.velocity);
        Vector3 localAngularVelocity = transform.InverseTransformDirection(rb.angularVelocity);

        //position
        if (!SpaceshipControls.instance.leftButton && !SpaceshipControls.instance.rightButton)
            ThrustersManager.instance.ThrustersSlideRight(Initiator.Gyroscope, (localVelocity.x < -stabilizationThreshold), Mathf.Abs(localVelocity.x) * 10); //Left
        if (!SpaceshipControls.instance.rightButton && !SpaceshipControls.instance.leftButton)
            ThrustersManager.instance.ThrustersSlideLeft(Initiator.Gyroscope, (localVelocity.x > stabilizationThreshold), Mathf.Abs(localVelocity.x) * 10); //Right
        if (!SpaceshipControls.instance.downButton && !SpaceshipControls.instance.upButton)
            ThrustersManager.instance.ThrustersSlideUp(Initiator.Gyroscope, (localVelocity.y < -stabilizationThreshold), Mathf.Abs(localVelocity.y) * 10); //Down
        if (!SpaceshipControls.instance.upButton && !SpaceshipControls.instance.downButton)
            ThrustersManager.instance.ThrustersSlideDown(Initiator.Gyroscope, (localVelocity.y > stabilizationThreshold), Mathf.Abs(localVelocity.y) * 10); //Up
        if (!SpaceshipControls.instance.backwarddButton && !SpaceshipControls.instance.forwardButton)
            ThrustersManager.instance.ThrustersForward(Initiator.Gyroscope, (localVelocity.z < -stabilizationThreshold), Mathf.Abs(localVelocity.z) * 10); //Backward
        if (!SpaceshipControls.instance.forwardButton && !SpaceshipControls.instance.backwarddButton)
            ThrustersManager.instance.ThrustersBackward(Initiator.Gyroscope, (localVelocity.z > stabilizationThreshold), Mathf.Abs(localVelocity.z) * 10); //Forward

        //rotation
        if (!SpaceshipControls.instance.pinchDown && !SpaceshipControls.instance.pinchUp)
            ThrustersManager.instance.ThrustersPinchDown(Initiator.Gyroscope, (localAngularVelocity.x < -stabilizationThreshold), Mathf.Abs(localAngularVelocity.x) * 10); //PinchUp
        if (!SpaceshipControls.instance.pinchUp && !SpaceshipControls.instance.pinchDown)
            ThrustersManager.instance.ThrustersPinchUp(Initiator.Gyroscope, (localAngularVelocity.x > stabilizationThreshold), Mathf.Abs(localAngularVelocity.x) * 10); //PinchDown
        if (!SpaceshipControls.instance.yawRight && !SpaceshipControls.instance.yawLeft)
            ThrustersManager.instance.ThrustersYawRight(Initiator.Gyroscope, (localAngularVelocity.y < -stabilizationThreshold), Mathf.Abs(localAngularVelocity.y) * 10); //YawLeft
        if (!SpaceshipControls.instance.yawLeft && !SpaceshipControls.instance.yawRight)
            ThrustersManager.instance.ThrustersYawLeft(Initiator.Gyroscope, (localAngularVelocity.y > stabilizationThreshold), Mathf.Abs(localAngularVelocity.y) * 10); //YawRight
        if (!SpaceshipControls.instance.rollLeftButton && !SpaceshipControls.instance.rollRightButton)
            ThrustersManager.instance.ThrustersRollLeft(Initiator.Gyroscope, (localAngularVelocity.z < -stabilizationThreshold), Mathf.Abs(localAngularVelocity.z) * 10); //RollRight
        if (!SpaceshipControls.instance.rollRightButton && !SpaceshipControls.instance.rollLeftButton)
            ThrustersManager.instance.ThrustersRollRight(Initiator.Gyroscope, (localAngularVelocity.z > stabilizationThreshold), Mathf.Abs(localAngularVelocity.z) * 10); //RollLeft
    }
}
