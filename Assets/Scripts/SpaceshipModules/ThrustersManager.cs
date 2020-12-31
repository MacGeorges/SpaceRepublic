using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ThrusterType { reactor, wingTopL, wingTopR, wingBotL, wingBotR, wingTipL, wingTipR, brake}
public enum Position { forward, middle, back, front, rear, top, bottom, tip, left, center, right}

public struct ThusterUpdateInfos { public List<Position> thrusterPositions; }

public class ThrustersManager : MonoBehaviour
{
    [SerializeField]
    private List<Thruster> thrusters;

    private List<ThusterUpdateInfos> thrustersInfosToUpdate;

    private void Start()
    {
        InitThrusters();
    }

    private void InitThrusters()
    {
        thrustersInfosToUpdate = new List<ThusterUpdateInfos>();

        foreach (Transform tmpTrans in transform)
        {
            Thruster tmpTruster = tmpTrans.GetComponent<Thruster>();

            if(tmpTruster)
            {
                thrusters.Add(tmpTruster);
            }
        }
    }

    public void ThrustersForward(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.rear);

        Actuator tmpAct;
        tmpAct.direction = Direction.backward;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if(Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if(Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersBackward(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.front);

        Actuator tmpAct;
        tmpAct.direction = Direction.forward;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersSlideUp(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.bottom);

        Actuator tmpAct;
        tmpAct.direction = Direction.SlideUp;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersSlideDown(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);

        Actuator tmpAct;
        tmpAct.direction = Direction.SlideDown;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersSlideLeft(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.tip);
        thrusterPositions.Add(Position.right);

        Actuator tmpAct;
        tmpAct.direction = Direction.SlideLeft;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersSlideRight(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.tip);
        thrusterPositions.Add(Position.left);

        Actuator tmpAct;
        tmpAct.direction = Direction.SlideRight;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersRollLeft(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.left);

        Actuator tmpAct;
        tmpAct.direction = Direction.RollLeft;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }

        thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.bottom);
        thrusterPositions.Add(Position.right);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersRollRight(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.right);
        
        Actuator tmpAct;
        tmpAct.direction = Direction.RollRight;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }   
            }
        }

        thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.bottom);
        thrusterPositions.Add(Position.left);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersYawLeft(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.back);
        thrusterPositions.Add(Position.left);
        thrusterPositions.Add(Position.tip);

        Actuator tmpAct;
        tmpAct.direction = Direction.YawLeft;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }

        thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.forward);
        thrusterPositions.Add(Position.right);
        thrusterPositions.Add(Position.tip);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersYawRight(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.back);
        thrusterPositions.Add(Position.right);
        thrusterPositions.Add(Position.tip);

        Actuator tmpAct;
        tmpAct.direction = Direction.YawRight;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }

        thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.forward);
        thrusterPositions.Add(Position.left);
        thrusterPositions.Add(Position.tip);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersPinchDown(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.forward);

        Actuator tmpAct;
        tmpAct.direction = Direction.PinchDown;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }

        thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.back);
        thrusterPositions.Add(Position.bottom);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }

    public void ThrustersPinchUp(bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.forward);
        thrusterPositions.Add(Position.bottom);

        Actuator tmpAct;
        tmpAct.direction = Direction.PinchUp;
        tmpAct.force = Force;

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }

        thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.back);
        thrusterPositions.Add(Position.top);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(tmpAct);
                }
                else
                {
                    tmpThruster.RemoveActuator(tmpAct);
                }
            }
        }
    }
}
