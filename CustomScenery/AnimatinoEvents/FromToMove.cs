

using System;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
[Serializable]
public class FromToMove : RideAnimationEvent
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
            return "From-To Move";
        }
    }
   

    public override void Enter()
    {
        lastTime = Time.realtimeSinceStartup;

        rotator.startFromTo();
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
