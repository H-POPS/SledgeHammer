﻿
using System;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
[Serializable]
public class ApplyRotation : RideAnimationEvent 
{
    [SerializeField]
    public MultipleRotationsHP rotator;
    [SerializeField]
    float lastTime;
    [SerializeField]
    public ParkitectObject obj;


    public override string EventName
    {
        get
        {
            return "ApplyRptations";
        }
    }
    
    

    public override void Enter()
    {
        
    }
    public override void Run()
    {
        if (rotator)
        {


            rotator.tick(Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            done = true;
            base.Run();
        }

    }
}
