using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Transform cursor;

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
