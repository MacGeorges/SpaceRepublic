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

    public Vector2 mousePosition;

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
        GetComponent<Rigidbody>().isKinematic = context.ReadValueAsButton();
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
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
        ClearMouseInputs();

        //Debug.Log("Mouse : " + mousePosition);

        if (mousePosition.x < ((Screen.width / 2) - deadZone))
        {
            Debug.Log("left");
            yawLeft = true;
        }

        if (mousePosition.x > ((Screen.width / 2) + deadZone))
        {
            Debug.Log("right");
            yawRight = true;
        }

        if (mousePosition.y < ((Screen.height / 2) - deadZone))
        {
            Debug.Log("down");
            pinchDown = true;
        }

        if (mousePosition.y > ((Screen.height / 2) + deadZone))
        {
            Debug.Log("up");
            pinchUp = true;
        }

        Debug.Log("=========================");
    }

    private void Update()
    {
        //Keyboard
        thrustersManager.ThrustersForward(forwardButton, 1);
        thrustersManager.ThrustersBackward(backwarddButton, 1);
        thrustersManager.ThrustersSlideUp(upButton, 1);
        thrustersManager.ThrustersSlideDown(downButton, 1);
        thrustersManager.ThrustersSlideLeft(leftButton, 1);
        thrustersManager.ThrustersSlideRight(rightButton, 1);
        thrustersManager.ThrustersRollLeft(rollLeftButton, 1);
        thrustersManager.ThrustersRollRight(rollRightButton, 1);

        //Mouse
        float CursorDistance = Vector2.Distance(UIManager.instance.cursor.transform.position, new Vector2(Screen.width / 2, Screen.height / 2));

        if (CursorDistance > deadZone)
        {
            MouseInput();
        }
        else
        {
            Debug.Log("Mouse Deadzone");
            ClearMouseInputs();
        }

        Debug.Log("Mouse Force X : " + Mathf.Abs(mousePosition.x - Screen.width / 2));
        Debug.Log("Mouse Force Y : " + Mathf.Abs(mousePosition.y - Screen.height / 2));

        thrustersManager.ThrustersYawLeft(yawLeft, (Mathf.Abs(mousePosition.x - Screen.width / 2) / (Screen.width / 2)));
        thrustersManager.ThrustersYawRight(yawRight, (Mathf.Abs(mousePosition.x - Screen.width / 2) / (Screen.width / 2)));
        thrustersManager.ThrustersPinchDown(pinchDown, (Mathf.Abs(mousePosition.y - Screen.height / 2) / (Screen.height / 2)));
        thrustersManager.ThrustersPinchUp(pinchUp, (Mathf.Abs(mousePosition.y - Screen.height / 2) / (Screen.height / 2)));
    }
}
