using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction { forward, backward, SlideUp, SlideDown, SlideLeft, SlideRight, RollLeft, RollRight, YawLeft, YawRight, PinchUp, PinchDown}

public struct Actuator { public Direction direction; public float force; }

public class SpaceshipControls : MonoBehaviour
{
    public ThrustersManager thrustersManager;

    [Header("Input parameters")]
    public float deadZone;
    public float speedLimit;

    [Header ("Debug Inputs")]
    public bool forwardButton;
    public bool backwarddButton;
    public bool upButton;
    public bool downButton;
    public bool leftButton;
    public bool rightButton;
    public bool rollLeftButton;
    public bool rollRightButton;

    public bool yawLeft;
    public bool yawRight;
    public bool pinchDown;
    public bool pinchUp;

    public bool boost;

    public Vector2 mousePosition;
    public Vector2 mouseWheel;

    public static SpaceshipControls instance;

    private void Start()
    {
        instance = this;
    }

    public void Forward(InputAction.CallbackContext context)
    {
        forwardButton = context.ReadValueAsButton();
    }

    public void Backward(InputAction.CallbackContext context)
    {
        backwarddButton = context.ReadValueAsButton();
    }

    public void Up(InputAction.CallbackContext context)
    {
        upButton = context.ReadValueAsButton();
    }

    public void Down(InputAction.CallbackContext context)
    {
        downButton = context.ReadValueAsButton();
    }

    public void Left(InputAction.CallbackContext context)
    {
        leftButton = context.ReadValueAsButton();
    }

    public void Right(InputAction.CallbackContext context)
    {
        rightButton = context.ReadValueAsButton();
    }

    public void BarrelLeft(InputAction.CallbackContext context)
    {
        rollLeftButton = context.ReadValueAsButton();
    }

    public void BarrelRight(InputAction.CallbackContext context)
    {
        rollRightButton = context.ReadValueAsButton();
    }

    public void SpaceBreak(InputAction.CallbackContext context)
    {
        //GetComponent<Rigidbody>().isKinematic = context.ReadValueAsButton();

        //SpaceshipGyroscope.instance.lockedMode = context.ReadValueAsButton();
        SpaceshipGyroscope.instance.ToggleLockedMode();
    }

    public void Boost(InputAction.CallbackContext context)
    {
        boost = context.ReadValueAsButton();
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
        MouseInput();
    }

    public void MouseWheel(InputAction.CallbackContext context)
    {
        mouseWheel = context.ReadValue<Vector2>();
    }

    private void ClearMouseInputs()
    {
        yawLeft = false;
        yawRight = false;
        pinchDown = false;
        pinchUp = false;
    }

    private void MouseInput()
    {

        float CursorDistance = Vector2.Distance(UIManager.instance.cursor.transform.position, new Vector2(Screen.width / 2, Screen.height / 2));

        ClearMouseInputs();

        if (CursorDistance > deadZone)
        {
            //Debug.Log("Mouse : " + mousePosition);

            if (mousePosition.x < ((Screen.width / 2) - deadZone))
            {
                //Debug.Log("left");
                yawLeft = true;
            }

            if (mousePosition.x > ((Screen.width / 2) + deadZone))
            {
                //Debug.Log("right");
                yawRight = true;
            }

            if (mousePosition.y < ((Screen.height / 2) - deadZone))
            {
                //Debug.Log("down");
                pinchDown = true;
            }

            if (mousePosition.y > ((Screen.height / 2) + deadZone))
            {
                //Debug.Log("up");
                pinchUp = true;
            }

            //Debug.Log("=========================");
        }
    }

    private void Update()
    {
        //if (SpaceshipGyroscope.instance.lockedMode)
        //{
        //    return;
        //}

        //Keyboard
        if (SpaceshipGyroscope.instance.lockedMode)
        {
            if (forwardButton)
                thrustersManager.ThrustersForward(forwardButton, 1);
            if (backwarddButton)
                thrustersManager.ThrustersBackward(backwarddButton, 1);
            if (upButton)
                thrustersManager.ThrustersSlideUp(upButton, 1);
            if (downButton)
                thrustersManager.ThrustersSlideDown(downButton, 1);
            if (leftButton)
                thrustersManager.ThrustersSlideLeft(leftButton, 1);
            if (rightButton)
                thrustersManager.ThrustersSlideRight(rightButton, 1);
            if (rollLeftButton)
                thrustersManager.ThrustersRollLeft(rollLeftButton, 1);
            if (rollRightButton)
                thrustersManager.ThrustersRollRight(rollRightButton, 1);
        }
        else
        {
            thrustersManager.ThrustersForward(forwardButton, 1);
            thrustersManager.ThrustersBackward(backwarddButton, 1);
            thrustersManager.ThrustersSlideUp(upButton, 1);
            thrustersManager.ThrustersSlideDown(downButton, 1);
            thrustersManager.ThrustersSlideLeft(leftButton, 1);
            thrustersManager.ThrustersSlideRight(rightButton, 1);
            thrustersManager.ThrustersRollLeft(rollLeftButton, 1);
            thrustersManager.ThrustersRollRight(rollRightButton, 1);
        }

        //Mouse
        //Debug.Log("Mouse Force X : " + Mathf.Abs(mousePosition.x - Screen.width / 2));
        //Debug.Log("Mouse Force Y : " + Mathf.Abs(mousePosition.y - Screen.height / 2));

        if (SpaceshipGyroscope.instance.lockedMode)
        {
            Debug.Log("Controls PinchDown " + pinchDown);
            if (yawLeft)
                thrustersManager.ThrustersYawLeft(yawLeft, (Mathf.Abs(mousePosition.x - Screen.width / 2) / (Screen.width / 2)));
            if (yawRight)
                thrustersManager.ThrustersYawRight(yawRight, (Mathf.Abs(mousePosition.x - Screen.width / 2) / (Screen.width / 2)));
            if (pinchDown)
                thrustersManager.ThrustersPinchDown(pinchDown, (Mathf.Abs(mousePosition.y - Screen.height / 2) / (Screen.height / 2)));
            if (pinchUp)
                thrustersManager.ThrustersPinchUp(pinchUp, (Mathf.Abs(mousePosition.y - Screen.height / 2) / (Screen.height / 2)));
        }
        else
        {
            thrustersManager.ThrustersYawLeft(yawLeft, (Mathf.Abs(mousePosition.x - Screen.width / 2) / (Screen.width / 2)));
            thrustersManager.ThrustersYawRight(yawRight, (Mathf.Abs(mousePosition.x - Screen.width / 2) / (Screen.width / 2)));
            thrustersManager.ThrustersPinchDown(pinchDown, (Mathf.Abs(mousePosition.y - Screen.height / 2) / (Screen.height / 2)));
            thrustersManager.ThrustersPinchUp(pinchUp, (Mathf.Abs(mousePosition.y - Screen.height / 2) / (Screen.height / 2)));
        }

        //Mouse Wheel
        if (mouseWheel.y > 0)
        {
            speedLimit += 0.1f;
            if (speedLimit > 1) { speedLimit = 1; }
        }
        if (mouseWheel.y < 0)
        {
            speedLimit -= 0.1f;
            if (speedLimit < 0) { speedLimit = 0; }
        }

        UIManager.instance.speedLimiter.value = speedLimit;

    }
}
