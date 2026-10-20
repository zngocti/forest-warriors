using UnityEngine;

public class DeadState : IState
{
    readonly Player _context;
    public DeadState(Player context)
    {
        _context = context;
    }

    public void Enter() => c.Animator.SetTrigger("Die");
    public void Tick(float dt) { }
    public void Exit() { }
}
