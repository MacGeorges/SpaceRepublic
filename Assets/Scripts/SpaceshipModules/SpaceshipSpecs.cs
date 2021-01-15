using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSpecs : MonoBehaviour
{
    [Header ("Max Translation Speeds")]
    public float MaxForwardSpeed;
    public float MaxLateralSpeed;
    public float MaxUpSpeed;

    [Header("Max Rotation Speeds")]
    public float MaxPitchSpeed;
    public float MaxYawSpeed;
    public float MaxRollSpeed;

    public static SpaceshipSpecs instance;

    void Start()
    {
        instance = this;
    }

    public bool IsWithingSpecs(Direction direction)
    {
        Rigidbody rb = SpaceshipAvionicsManager.instance.gyroscope.rb;
        Transform tr = SpaceshipAvionicsManager.instance.gyroscope.transform;

        switch (direction)
        {
            case Direction.Forward:
                return tr.InverseTransformDirection(rb.velocity).z < (MaxForwardSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.Backward:
                return tr.InverseTransformDirection(rb.velocity).z > (-MaxForwardSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.SlideLeft:
                return tr.InverseTransformDirection(rb.velocity).x > (-MaxLateralSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.SlideRight:
                return tr.InverseTransformDirection(rb.velocity).x < (MaxLateralSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.SlideUp:
                return tr.InverseTransformDirection(rb.velocity).y < (MaxUpSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.SlideDown:
                return tr.InverseTransformDirection(rb.velocity).y > (-MaxUpSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.PitchDown:
                return tr.InverseTransformDirection(rb.angularVelocity).x < (MaxPitchSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.PitchUp:
                return tr.InverseTransformDirection(rb.angularVelocity).x > (-MaxPitchSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.YawLeft:
                return tr.InverseTransformDirection(rb.angularVelocity).y > (-MaxYawSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.YawRight:
                return tr.InverseTransformDirection(rb.angularVelocity).y < (MaxYawSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.RollLeft:
                return tr.InverseTransformDirection(rb.angularVelocity).z < (MaxRollSpeed * SpaceshipControls.instance.speedLimit);
            case Direction.RollRight:
                return tr.InverseTransformDirection(rb.angularVelocity).z > (-MaxRollSpeed * SpaceshipControls.instance.speedLimit);
            default:
                return false;
        }
    }
}
