using System;
using UnityEngine;
[ExecuteInEditMode]
[Serializable]
public class MoverHP : motor
{

    private enum State
    {
        RUNNING,
        STOPPED
    }
    public string axisPath;
    [SerializeField]
    public Transform axis;
    [SerializeField]
    public Vector3 originalRotationValue;
    [SerializeField]
    private Vector3 fromPosition;
    [SerializeField]
    public Vector3 toPosition;
    [SerializeField]
    public float duration = 10f;

    [SerializeField]
    private MoverHP.State currentState = MoverHP.State.STOPPED;

    [SerializeField]
    private float currentPosition = 1f;

    [SerializeField]
    private int direction = -1;

    public override void Reset()
    {
        if (axis)
            axis.localPosition = originalRotationValue;
        currentPosition = 1f;
        base.Reset();
    }
    public override string EventName
    {
        get
        {
            return "Mover";
        }
    }
    
    public override void Enter()
    {
        if(axis)
        originalRotationValue = axis.localPosition;
        this.currentPosition = 0f;
        Initialize(axis, axis.localPosition, toPosition, duration);
        base.Enter();
    }
    public void Initialize(Transform axis, Vector3 fromPosition, Vector3 toPosition, float duration)
    {
        this.axis = axis;
        this.fromPosition = fromPosition;

        Debug.Log("pos: " + toPosition);
        this.toPosition = toPosition;
        Debug.Log("pos: " + toPosition);
        this.duration = duration;
        this.setPosition();
    }

    public bool startFromTo()
    {
        if (this.direction != 1)
        {
            this.direction = 1;
            this.currentPosition = 0f;
            this.currentState = MoverHP.State.RUNNING;
            return true;
        }
        return false;
    }

    public bool startToFrom()
    {
        if (this.direction != -1)
        {
            this.direction = -1;
            this.currentPosition = 0f;
            this.currentState = MoverHP.State.RUNNING;
            return true;
        }
        return false;
    }

    public bool reachedTarget()
    {
        return this.currentState == MoverHP.State.STOPPED && this.currentPosition >= 1f;
    }

    public void tick(float dt)
    {
        this.currentPosition += dt * 1f / this.duration;
        if (this.currentPosition >= 1f)
        {
            this.currentPosition = 1f;
            this.currentState = MoverHP.State.STOPPED;
        }
        this.setPosition();
    }

    private void setPosition()
    {
        Vector3 a;
        Vector3 b;
        if (this.direction == 1)
        {
            a = this.fromPosition;
            b = this.toPosition;
        }
        else
        {
            a = this.toPosition;
            b = this.fromPosition;
        }
        this.axis.localPosition = Vector3.Lerp(a, b, Mathfx.Hermite(0f, 1f, this.currentPosition));
    }
}
