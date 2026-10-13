using UnityEngine;

public class StateMachine<T>
{
    public State<T> Current { get; private set; }
    public void Change(State<T> next)
    {
        Current?.Exit();
        Current = next;
        Current.Enter();
    }
    public void Tick(float dt) => Current?.Tick(dt);
}
