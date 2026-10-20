using UnityEngine;

public class LocomotionState : IState
{
    readonly Player _context;
    public LocomotionState(Player context)
    {
        _context = context;
    }

    public void Enter() { }
    public void Exit() => _context.Animator.SetFloat("Speed", 0f);

    public void Tick(float dt)
    {
        if (_context.Input.DashPressed) { _context.Body.Change(_context.States.Dash); return; }

        bool locked = _context.Action.Current is ILocksMovement;
        Vector3 dir = locked ? Vector3.zero : _context.Input.MoveDir;

        _context.DesiredVelocity = dir * _context.MoveSpeed;
        if (dir.sqrMagnitude > 0.01f)
        {
            _context.FacingDir = dir.normalized;
            _context.Controller.transform.rotation = Quaternion.LookRotation(_context.FacingDir);
        }
        _context.Animator.SetFloat("Speed", dir.magnitude);
    }
}
