using UnityEngine;

public class JumpState : IState
{
    readonly Player _context;
    float _duration = 0.25f;
    float _speed = 14f;
    float _timer;
    Vector3 _direction;

    public JumpState(Player context)
    {
        _context = context;
    }

    public void Enter()
    {
        _timer = 0f;
        _direction = _context.Input.FaceDir.sqrMagnitude > 0.01f ? _context.Input.MoveDir.normalized : _context.Movement.FacingDir;
        _context.Animation.StartJump();
    }

    public void Tick(float dt)
    {
        _timer += dt;
        _context.Movement.Move(_direction * _speed, false);

        if (_timer >= _duration)
        {
            _context.FSM.Change(_context.States.Locomotion);
        }
    }

    public void Exit() { }
}
