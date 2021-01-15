using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceshipGyroscope : MonoBehaviour
{
    private Vector3 lastPosition;
    private Vector3 lastWorldPosition;
    private Vector3 lastRotation;

    public float stabilizationThreshold;

    public bool lockedMode;

    public Rigidbody rb;

    void Start()
    {
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
        {
            ThrustersManager.instance.ThrustersSlideRight(Initiator.Gyroscope, (localVelocity.x < -stabilizationThreshold), Mathf.Abs(localVelocity.x) * 10); //Left
        }
        else
        {
            ThrustersManager.instance.ThrustersSlideRight(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.rightButton && !SpaceshipControls.instance.leftButton)
        {
            ThrustersManager.instance.ThrustersSlideLeft(Initiator.Gyroscope, (localVelocity.x > stabilizationThreshold), Mathf.Abs(localVelocity.x) * 10); //Right
        }
        else
        {
            ThrustersManager.instance.ThrustersSlideLeft(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.downButton && !SpaceshipControls.instance.upButton)
        {
            ThrustersManager.instance.ThrustersSlideUp(Initiator.Gyroscope, (localVelocity.y < -stabilizationThreshold), Mathf.Abs(localVelocity.y) * 10); //Down
        }
        else
        {
            ThrustersManager.instance.ThrustersSlideUp(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.upButton && !SpaceshipControls.instance.downButton)
        {
            ThrustersManager.instance.ThrustersSlideDown(Initiator.Gyroscope, (localVelocity.y > stabilizationThreshold), Mathf.Abs(localVelocity.y) * 10); //Up
        }
        else
        {
            ThrustersManager.instance.ThrustersSlideDown(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.backwarddButton && !SpaceshipControls.instance.forwardButton)
        {
            ThrustersManager.instance.ThrustersForward(Initiator.Gyroscope, (localVelocity.z < -stabilizationThreshold), Mathf.Abs(localVelocity.z) * 10); //Backward
        }
        else
        {
            ThrustersManager.instance.ThrustersForward(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.forwardButton && !SpaceshipControls.instance.backwarddButton)
        {
            ThrustersManager.instance.ThrustersBackward(Initiator.Gyroscope, (localVelocity.z > stabilizationThreshold), Mathf.Abs(localVelocity.z) * 10); //Forward
        }
        else
        {
            ThrustersManager.instance.ThrustersBackward(Initiator.Gyroscope, false, 0);
        }

        //rotation
        if (!SpaceshipControls.instance.pinchDown && !SpaceshipControls.instance.pinchUp)
        {
            ThrustersManager.instance.ThrustersPitchDown(Initiator.Gyroscope, (localAngularVelocity.x < -stabilizationThreshold), Mathf.Abs(localAngularVelocity.x) * 10); //PinchUp
        }
        else
        {
            ThrustersManager.instance.ThrustersPitchDown(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.pinchUp && !SpaceshipControls.instance.pinchDown)
        {
            ThrustersManager.instance.ThrustersPitchUp(Initiator.Gyroscope, (localAngularVelocity.x > stabilizationThreshold), Mathf.Abs(localAngularVelocity.x) * 10); //PinchDown
        }
        else
        {
            ThrustersManager.instance.ThrustersPitchUp(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.yawRight && !SpaceshipControls.instance.yawLeft)
        {
            ThrustersManager.instance.ThrustersYawRight(Initiator.Gyroscope, (localAngularVelocity.y < -stabilizationThreshold), Mathf.Abs(localAngularVelocity.y) * 10); //YawLeft
        }
        else
        {
            ThrustersManager.instance.ThrustersYawRight(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.yawLeft && !SpaceshipControls.instance.yawRight)
        {
            ThrustersManager.instance.ThrustersYawLeft(Initiator.Gyroscope, (localAngularVelocity.y > stabilizationThreshold), Mathf.Abs(localAngularVelocity.y) * 10); //YawRight
        }
        else
        {
            ThrustersManager.instance.ThrustersYawLeft(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.rollLeftButton && !SpaceshipControls.instance.rollRightButton)
        {
            ThrustersManager.instance.ThrustersRollLeft(Initiator.Gyroscope, (localAngularVelocity.z < -stabilizationThreshold), Mathf.Abs(localAngularVelocity.z) * 10); //RollRight
        }
        else
        {
            ThrustersManager.instance.ThrustersRollLeft(Initiator.Gyroscope, false, 0);
        }

        if (!SpaceshipControls.instance.rollRightButton && !SpaceshipControls.instance.rollLeftButton)
        {
            ThrustersManager.instance.ThrustersRollRight(Initiator.Gyroscope, (localAngularVelocity.z > stabilizationThreshold), Mathf.Abs(localAngularVelocity.z) * 10); //RollLeft
        }
        else
        {
            ThrustersManager.instance.ThrustersRollRight(Initiator.Gyroscope, false, 0);
        }
    }
}
