using UnityEngine;

public class HurtState : IState
{
    readonly Player _context;

    public HurtState(Player context)
    {
        _context = context;
    }

    public void Enter()
    { 
        _context.Animation.StartHurt();
    }

    public void Tick(float dt)
    {
        float normalizedTime;

        if (_context.Animation.GetNormalizedTime(PlayerAnimation.StateHurt, out normalizedTime) && normalizedTime >= 1.0f)
        {
            _context.FSM.Change(_context.States.ActionIdle);
        }
    }
    
    public void Exit() { }
}
