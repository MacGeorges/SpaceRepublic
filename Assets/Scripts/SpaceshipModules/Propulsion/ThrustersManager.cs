using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ThrusterType { reactor, wingTopL, wingTopR, wingBotL, wingBotR, wingTipL, wingTipR, brake}
public enum Position { forward, middle, back, front, rear, top, bottom, tip, left, center, right}

public struct ThusterUpdateInfos { public List<Position> thrusterPositions; }

public class ThrustersManager : MonoBehaviour
{
    public List<Thruster> thrusters;

    private List<ThusterUpdateInfos> thrustersInfosToUpdate;

    public static ThrustersManager instance;

    void Start()
    {
        instance = this;
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

    public void ThrustersForward(Initiator initiator, bool Enable, float Force)
    {
        //Debug.Log("Thrusters Forward");
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.rear);

        Actuator tmpAct = new Actuator(initiator, Direction.Backward, Force);

        foreach (Thruster tmpThruster in thrusters)
        {
            if(Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if(Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.Forward) || initiator == Initiator.Gyroscope))
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

    public void ThrustersBackward(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.front);

        Actuator tmpAct = new Actuator(initiator, Direction.Forward, Force);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.Backward) || initiator == Initiator.Gyroscope))
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

    public void ThrustersSlideUp(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.bottom);

        Actuator tmpAct = new Actuator(initiator, Direction.SlideUp, Force);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.SlideUp) || initiator == Initiator.Gyroscope))
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

    public void ThrustersSlideDown(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);

        Actuator tmpAct = new Actuator(initiator, Direction.SlideDown, Force);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.SlideDown) || initiator == Initiator.Gyroscope))
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

    public void ThrustersSlideLeft(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.tip);
        thrusterPositions.Add(Position.right);

        Actuator tmpAct = new Actuator(initiator, Direction.SlideLeft, Force);       

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.SlideLeft) || initiator == Initiator.Gyroscope))
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

    public void ThrustersSlideRight(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.tip);
        thrusterPositions.Add(Position.left);

        Actuator tmpAct = new Actuator(initiator, Direction.SlideRight, Force);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.SlideRight) || initiator == Initiator.Gyroscope))
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

    public void ThrustersRollLeft(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.left);

        Actuator tmpAct = new Actuator(initiator, Direction.RollLeft, Force);    

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.RollLeft) || initiator == Initiator.Gyroscope))
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
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.RollLeft) || initiator == Initiator.Gyroscope))
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

    public void ThrustersRollRight(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.right);
        
        Actuator tmpAct = new Actuator(initiator, Direction.RollRight, Force);      

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.RollRight) || initiator == Initiator.Gyroscope))
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
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.RollRight) || initiator == Initiator.Gyroscope))
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

    public void ThrustersYawLeft(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.back);
        thrusterPositions.Add(Position.left);
        thrusterPositions.Add(Position.tip);

        Actuator tmpAct = new Actuator(initiator, Direction.YawLeft, Force);    

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.YawLeft) || initiator == Initiator.Gyroscope))
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
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.YawLeft) || initiator == Initiator.Gyroscope))
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

    public void ThrustersYawRight(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.back);
        thrusterPositions.Add(Position.right);
        thrusterPositions.Add(Position.tip);

        Actuator tmpAct = new Actuator(initiator, Direction.YawRight, Force);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.YawRight) || initiator == Initiator.Gyroscope))
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
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.YawRight) || initiator == Initiator.Gyroscope))
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

    public void ThrustersPitchDown(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.top);
        thrusterPositions.Add(Position.forward);

        Actuator tmpAct = new Actuator(initiator, Direction.PitchDown, Force);

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.PitchDown) || initiator == Initiator.Gyroscope))
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
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.PitchDown) || initiator == Initiator.Gyroscope))
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

    public void ThrustersPitchUp(Initiator initiator, bool Enable, float Force)
    {
        List<Position> thrusterPositions = new List<Position>();

        thrusterPositions.Add(Position.forward);
        thrusterPositions.Add(Position.bottom);

        Actuator tmpAct = new Actuator(initiator, Direction.PitchUp, Force);     

        foreach (Thruster tmpThruster in thrusters)
        {
            if (Utility.ContainsAllPositions(tmpThruster.thrusterPositions, thrusterPositions))
            {
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.PitchUp) || initiator == Initiator.Gyroscope))
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
                if (Enable && (SpaceshipSpecs.instance.IsWithingSpecs(Direction.PitchUp) || initiator == Initiator.Gyroscope))
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
