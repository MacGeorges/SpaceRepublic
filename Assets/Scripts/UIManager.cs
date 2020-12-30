using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header ("UI Elements")]
    public Transform cursor;
    public Slider speedLimiter;

    public static UIManager instance;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        cursor.transform.position = SpaceshipControls.instance.mousePosition;
    }
}
