

using System;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
[Serializable]
public class StopRotator : RideAnimationEvent
{
    [SerializeField]
    public RotatorHP rotator;
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
            return "StopRotator";
        }
    }
   

    public override void Enter()
    {
        lastTime = Time.realtimeSinceStartup;

        rotator.stop();
        base.Enter();
    }
    public override void Run()
    {

        if (rotator)
        {
            
            
            rotator.tick(Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            if (rotator.isStopped())
            {
                done = true;
            }
            base.Run();
        }
        
    }
}
