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
                return tr.InverseTransformDirection(rb.velocity).z < MaxForwardSpeed;
            case Direction.Backward:
                return tr.InverseTransformDirection(rb.velocity).z > -MaxForwardSpeed;
            case Direction.SlideLeft:
                return tr.InverseTransformDirection(rb.velocity).x > -MaxLateralSpeed;
            case Direction.SlideRight:
                return tr.InverseTransformDirection(rb.velocity).x < MaxLateralSpeed;
            case Direction.SlideUp:
                return tr.InverseTransformDirection(rb.velocity).y < MaxUpSpeed;
            case Direction.SlideDown:
                return tr.InverseTransformDirection(rb.velocity).y > -MaxUpSpeed;
            case Direction.PitchDown:
                return tr.InverseTransformDirection(rb.angularVelocity).x < MaxPitchSpeed;
            case Direction.PitchUp:
                return tr.InverseTransformDirection(rb.angularVelocity).x > -MaxPitchSpeed;
            case Direction.YawLeft:
                return tr.InverseTransformDirection(rb.angularVelocity).y > -MaxYawSpeed;
            case Direction.YawRight:
                return tr.InverseTransformDirection(rb.angularVelocity).y < MaxYawSpeed;
            case Direction.RollLeft:
                return tr.InverseTransformDirection(rb.angularVelocity).z < MaxRollSpeed;
            case Direction.RollRight:
                return tr.InverseTransformDirection(rb.angularVelocity).z > -MaxRollSpeed;
            default:
                return false;
        }
    }
}
