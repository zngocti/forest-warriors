using UnityEngine;

public class JumpState : IState
{
    readonly Player _context;
    float _upDuration = 0.65f;
    float _peakDuration = 0.2f;
    float _downDuration = 0.4f;
    float _jumpHeight = 3.0f;
    float _verticalVelocity = 1;
    float _horizontalSpeed = 10.0f;
    float _customGravityUp = 0f;
    float _customGraityDown = 0f;
    float _timer;
    Vector3 _direction;

    public JumpState(Player context)
    {
        _context = context;

        if (_upDuration <= 0)
        {
            _upDuration = 0.001f;
        }
    }

    public void Enter()
    {
        _timer = 0f;
        _direction = _context.Input.GetFaceDirRelativeTo(_context.transform.position).sqrMagnitude > 0.01f ? _context.Input.MoveDir.normalized : _context.Movement.FacingDir;
        _verticalVelocity = (2.0f * _jumpHeight) / _upDuration;
        _customGravityUp = (-2.0f * _jumpHeight) / (_upDuration * _upDuration);
        _customGraityDown = (-2.0f * _jumpHeight) / (_downDuration * _downDuration);
        _context.Animation.StartJump();
    }

    public void Tick(float dt)
    {
        Vector3 direction = _direction * _horizontalSpeed;

        direction.y = _verticalVelocity;
        _context.Movement.Move(direction, SpeedMode.Ignore, SpeedMode.Ignore);
        _context.Movement.FaceTo(_direction);
        _timer += dt;

        if (_timer <= _upDuration )
        {
            _verticalVelocity += _customGravityUp;
        }
        else if (_timer <= _upDuration + _peakDuration)
        {
            _verticalVelocity = 0;
        }
        else if (_timer <= _upDuration + _peakDuration + _downDuration)
        {
            _verticalVelocity += _customGraityDown;
        }
        
        //just for testing
        if (_timer > _upDuration + _peakDuration + _downDuration)
        {
            _context.FSM.Change(_context.States.ActionIdle);            
        }

        //this one is the real
        if (_timer > _upDuration + _peakDuration && _context.Movement.OnFloor)
        {
            _context.FSM.Change(_context.States.ActionIdle);            
        }
    }

    public void Exit() { }
}
