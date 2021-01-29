using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceshipCameraManager : MonoBehaviour
{
    public Transform pointingTarget;

    void Update()
    {
        Debug.Log("Camera position : " + SpaceshipControls.instance.mousePosition.x + " - " + SpaceshipControls.instance.mousePosition.y);

        transform.position = SpaceshipAvionicsManager.instance.transform.position;
        transform.eulerAngles = new Vector3 (-SpaceshipControls.instance.mousePosition.y, SpaceshipControls.instance.mousePosition.x, 0);

        //pointingTarget.position = Camera.main.ScreenToWorldPoint(new Vector3(SpaceshipControls.instance.mousePosition.x, SpaceshipControls.instance.mousePosition.y, 10));
        //transform.LookAt(pointingTarget);
    }
}
