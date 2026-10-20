using UnityEngine;

public class AttackState : IState
{
    readonly Player _context;

    public AttackState(Player context)
    {
        _context = context;
    }

    public void Enter()
    { 
        _context.Animation.StartAttack();
    }

    public void Tick(float dt)
    {
        float normalizedTime;

        if (_context.Animation.GetNormalizedTime(PlayerAnimation.StateAttack, out normalizedTime) && normalizedTime >= 1.0f)
        {
            _context.FSM.Change(_context.States.ActionIdle);
        }
    }

    public void Exit() { } 
}
