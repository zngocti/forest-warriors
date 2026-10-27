using UnityEngine;

public class DashState : IState
{
    readonly Player _context;
    float _duration = 0.75f;
    float _speed = 21f;
    float _timer;
    Vector3 _direction;

    public DashState(Player context)
    {
        _context = context;
    }

    public void Enter()
    {
        _timer = 0f;
        _direction = _context.Input.GetFaceDirRelativeTo(_context.transform.position).sqrMagnitude > 0.01f ? _context.Input.MoveDir.normalized : _context.Movement.FacingDir;
        _context.Animation.StartDash();
    }

    public void Tick(float dt)
    {
        _timer += dt;
        _context.Movement.Move(_direction * _speed, false);
        _context.Movement.FaceTo(_direction);

        if (_timer >= _duration)
        {
            _context.FSM.Change(_context.States.ActionIdle);
        }
    }

    public void Exit() { }
}
