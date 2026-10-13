using UnityEngine;

public abstract class State<T>
{
    protected readonly T c;
    protected State(T context) { c = context; }
    public virtual void Enter() { }
    public virtual void Tick(float dt) { }
    public virtual void Exit() { }
}
