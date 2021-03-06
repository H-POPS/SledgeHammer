﻿
using System;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
[Serializable]
public class SpinRotater : RideAnimationEvent 
{
    [SerializeField]
    public RotatorHP rotator;
    [SerializeField]
    public bool spin = false;
    [SerializeField]
    public int spins = 1;
    [SerializeField]
    float lastTime;
    [SerializeField]
    public ParkitectObject obj;
    public override void Check(RideAnimation RA)
    {
        foreach (RotatorHP R in RA.motors.OfType<RotatorHP>().ToList())
            if (R.Identifier == identifierMotor)
                rotator = R;
        base.Check(RA);
    }
    
        
    

    public override string EventName
    {
        get
        {
            return "SpinRotator";
        }
    }
    

    public override void Enter()
    {
        lastTime = Time.realtimeSinceStartup;
        rotator.resetRotations();
        base.Enter();
    }
    public override void Run()
    {
        if (rotator != null)
        {


            rotator.tick(Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            if (spin)
            {
                if (rotator.getCompletedRotationsCount() >= spins)
                {
                    done = true;
                }
            }
            else
            { done = true;}
            
            base.Run();
        }

    }
}
