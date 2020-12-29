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

    public void ThrustersForward(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.rear);

        foreach (Thruster tmpThruster in thrusters)
        {
            if(Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if(Enable)
                {
                    tmpThruster.AddActuator(Direction.backward);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.backward);
                }
            }
        }
    }

    public void ThrustersBackward(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.front);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(Direction.forward);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.forward);
                }
            }
        }
    }

    public void ThrustersSlideUp(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.bottom);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(Direction.SlideUp);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.SlideUp);
                }
            }
        }
    }

    public void ThrustersSlideDown(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(Direction.SlideUp);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.SlideUp);
                }
            }
        }
    }

    public void ThrustersSlideLeft(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.tip);
        thrusterPositions.Add(Position.right);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(Direction.SlideLeft);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.SlideLeft);
                }
            }
        }
    }

    public void ThrustersSlideRight(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.tip);
        thrusterPositions.Add(Position.left);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(Direction.SlideRight);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.SlideRight);
                }
            }
        }
    }

    public void ThrustersBarrelLeft(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.left);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(Direction.BarrelLeft);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.BarrelLeft);
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
                    tmpThruster.AddActuator(Direction.BarrelLeft);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.BarrelLeft);
                }
            }
        }
    }

    public void ThrustersBarrelRight(bool Enable)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.right);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable)
                {
                    tmpThruster.AddActuator(Direction.BarrelRight);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.BarrelRight);
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
                    tmpThruster.AddActuator(Direction.BarrelRight);
                }
                else
                {
                    tmpThruster.RemoveActuator(Direction.BarrelRight);
                }
            }
        }
    }
}
