using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction { forward, backward, SlideUp, SlideDown, SlideLeft, SlideRight, BarrelLeft, BarrelRight}

public class SpaceshipControls : MonoBehaviour
{
    public ThrustersManager thrustersManager;

    public bool forwardButton;
    public bool backwarddButton;
    public bool upButton;
    public bool downButton;
    public bool leftButton;
    public bool rightButton;
    public bool barrelLeftButton;
    public bool barrelRightButton;


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
        barrelLeftButton = context.ReadValueAsButton();
    }

    public void BarrelRight(InputAction.CallbackContext context)
    {
        barrelRightButton = context.ReadValueAsButton();
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        return;

        Vector2 mousePosition = context.ReadValue<Vector2>();

        //Debug.Log("Mouse : " + mousePosition);

        if (mousePosition.x < (Screen.width / 2))
        {
            //Debug.Log("left");
            thrustersManager.ThrustersSlideLeft(true);
            //thrustersManager.ThrustersSlideRight(false);
        }

        if (mousePosition.x > (Screen.width / 2))
        {
            //Debug.Log("right");
            //thrustersManager.ThrustersSlideLeft(false);
            thrustersManager.ThrustersSlideRight(true);
        }

        if (mousePosition.y < (Screen.height / 2))
        {
            //Debug.Log("up");
            //thrustersManager.ThrustersSlideUp(false);
            thrustersManager.ThrustersSlideDown(true);
        }

        if (mousePosition.y > (Screen.height / 2))
        {
            //Debug.Log("down");
            thrustersManager.ThrustersSlideUp(true);
            //thrustersManager.ThrustersSlideDown(false);
        }
    }

    private void Update()
    {
        thrustersManager.ThrustersForward(forwardButton);
        thrustersManager.ThrustersBackward(backwarddButton);
        thrustersManager.ThrustersSlideUp(upButton);
        thrustersManager.ThrustersSlideDown(downButton);
        thrustersManager.ThrustersSlideLeft(leftButton);
        thrustersManager.ThrustersSlideRight(rightButton);
        thrustersManager.ThrustersBarrelLeft(barrelLeftButton);
        thrustersManager.ThrustersBarrelRight(barrelRightButton);
    }
}
