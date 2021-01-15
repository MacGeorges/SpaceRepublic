using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction { Forward, Backward, SlideUp, SlideDown, SlideLeft, SlideRight, RollLeft, RollRight, YawLeft, YawRight, PitchUp, PitchDown}

public class SpaceshipControls : MonoBehaviour
{
    public ThrustersManager thrustersManager;

    [Header("Input parameters")]
    public bool Mouse;
    public bool Keyboard;
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

        //SpaceshipAvionicsManager.instance.gyroscope.lockedMode = context.ReadValueAsButton();
        SpaceshipAvionicsManager.instance.gyroscope.ToggleLockedMode();
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
        //if (SpaceshipAvionicsManager.instance.gyroscope.lockedMode)
        //{
        //    return;
        //}

        //Keyboard
        if (Keyboard)
        {
            thrustersManager.ThrustersForward(Initiator.User, forwardButton, 1); ;
            thrustersManager.ThrustersBackward(Initiator.User, backwarddButton, 1);
            thrustersManager.ThrustersSlideUp(Initiator.User, upButton, 1);
            thrustersManager.ThrustersSlideDown(Initiator.User, downButton, 1);
            thrustersManager.ThrustersSlideLeft(Initiator.User, leftButton, 1);
            thrustersManager.ThrustersSlideRight(Initiator.User, rightButton, 1);
            thrustersManager.ThrustersRollLeft(Initiator.User, rollLeftButton, 1);
            thrustersManager.ThrustersRollRight(Initiator.User, rollRightButton, 1);
        }

        //Mouse
        //Debug.Log("Mouse Force X : " + Mathf.Abs(((mousePosition.x / Screen.width) - 0.5f)) * 2);
        //Debug.Log("Mouse Force Y : " + Mathf.Abs(((mousePosition.y / Screen.height) - 0.5f)) * 2);
        if (Mouse)
        { 
            thrustersManager.ThrustersYawLeft(Initiator.User, yawLeft, Mathf.Abs(((mousePosition.x / Screen.width) - 0.5f)) * 2);
            thrustersManager.ThrustersYawRight(Initiator.User, yawRight, Mathf.Abs(((mousePosition.x / Screen.width) - 0.5f)) * 2);
            thrustersManager.ThrustersPitchDown(Initiator.User, pinchDown, Mathf.Abs(((mousePosition.y / Screen.height) - 0.5f)) * 2);
            thrustersManager.ThrustersPitchUp(Initiator.User, pinchUp, Mathf.Abs(((mousePosition.y / Screen.height) - 0.5f)) * 2);

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
}
