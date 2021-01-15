using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipAvionicsManager : MonoBehaviour
{
    public static SpaceshipAvionicsManager instance;

    public SpaceshipSpeedometer speedometer;
    public SpaceshipGyroscope gyroscope;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
