using UnityEngine;
using System;
[Serializable]
[ExecuteInEditMode]
public class Wait : RideAnimationEvent
{
    [SerializeField]
    public float seconds;
    [SerializeField]
    float timeLimit;
    public override string EventName
    {
        get
        {
            return "Wait";
        }
    }
   

    public override void Enter()
    {
        
        timeLimit = Time.realtimeSinceStartup + seconds;
        base.Enter();
    }
    public override void Run()
    {
        if (Time.realtimeSinceStartup > timeLimit)
        {

            done = true;
        }
        else
        {

        }
        base.Run();
    }

}
