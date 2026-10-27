using UnityEngine;

public class ActionIdleState : IState
{
    readonly Player _context;

    public ActionIdleState(Player context)
    {
        _context = context;
    }

    public void Enter() { }
    public void Exit() { }

    public void Tick(float dt)
    {
        if (CheckStateChangeInput())
        {
            return;
        }

        _context.Movement.Move(_context.Input.MoveDir, true);
        _context.Movement.FaceTo(_context.Input.GetFaceDirRelativeTo(_context.transform.position));
        _context.Animation.UpdateSpeed(_context.Input.MoveDir.magnitude);
    }

    bool CheckStateChangeInput()
    {
        if (_context.Input.AttackPressed)
        {
            _context.Input.ConsumeAttack();
            _context.FSM.Change(_context.States.Attack);
            return true;           
        }
        else if (_context.Input.InteractPressed && _context.InteractionTarget != null )
        {
            _context.Input.ConsumeAttack();
            _context.FSM.Change(_context.States.Interact);
            return true;
        }
        else if (_context.Input.JumpPressed && _context.CanJump)
        {
            _context.Input.ConsumeJump();
            _context.FSM.Change(_context.States.Jump);
            return true;
        }
        else if (_context.Input.DashPressed && _context.CanDash)
        {
            _context.Input.ConsumeDash();
            _context.FSM.Change(_context.States.Dash);
            return true;           
        }

        return false;
    }
}
