using UnityEngine;

public class DashState : IState
{
    readonly Player _context;
    float Duration = 0.25f;
    float Speed = 14f;
    float t; Vector3 dir;

    public DashState(Player context)
    {
        _context = context;
    }

    public void Enter()
    {
        t = 0f;
        dir = _context.Input.MoveDir.sqrMagnitude > 0.01f ? _context.Input.MoveDir.normalized : _context.FacingDir;
        _context.Animator.SetTrigger("Dash");
    }

    public void Tick(float dt)
    {
        t += dt;
        _context.DesiredVelocity = dir * Speed;
        if (t >= Duration) _context.Body.Change(_context.States.Locomotion);
    }

    public void Exit() { }

    public bool CanBeInterruptedBy(in DamageInfo info) => info.InterruptsDash;
}
