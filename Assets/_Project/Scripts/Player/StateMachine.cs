using UnityEngine;

public class StateMachine
{
    public IState Current { get; private set; }

    public void Change(IState next)
    {
        Current?.Exit();
        Current = next;
        Current?.Enter();
    }

    public void Tick(float dt) => Current?.Tick(dt);
}
