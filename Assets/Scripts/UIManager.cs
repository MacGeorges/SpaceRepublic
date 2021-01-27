using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("UI Elements")]
    public Transform cursor;
    public Text speedometer;
    public Slider speedLimiter;
    public Text lockUnlock;

    public static UIManager instance;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        cursor.transform.position = SpaceshipControls.instance.mousePosition;
        speedometer.text = Mathf.Abs(SpaceshipAvionicsManager.instance.speedometer.currentSpeed).ToString("F0");
        lockUnlock.text = SpaceshipAvionicsManager.instance.gyroscope.lockedMode ? "L" : "U";
    }
}
