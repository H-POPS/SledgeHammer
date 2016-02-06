
using System;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
[Serializable]
public class ToFromMove : RideAnimationEvent
{
    [SerializeField]
    public MoverHP rotator;
    [SerializeField]
    public ParkitectObject obj;
    [SerializeField]
    float lastTime;
    public override string EventName
    {
        get
        {
            return "To-From Move";
        }
    }
    
    public override void Enter()
    {
        lastTime = Time.realtimeSinceStartup;

        rotator.startToFrom();
        base.Enter();
    }
    public override void Run()
    {

        if (rotator)
        {
            
            
            rotator.tick(Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            if (rotator.reachedTarget())
            {
                done = true;
            }
            base.Run();
        }
        
    }
}
