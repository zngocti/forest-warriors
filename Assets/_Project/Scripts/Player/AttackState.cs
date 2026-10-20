using UnityEngine;

public class AttackState : IState
{
    readonly Player _context;
    float t;
    public AttackState(Player context)
    {
        _context = context;
    }

    public void Enter()
    { 
        t = 0.4f;
        _context.Animation.StartAttack();
    }

    public void Tick(float dt)
    {

        // Obtenemos la información de la capa base (índice 0)
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Verificamos que estamos en el estado de ataque y que el tiempo normalizado es >= 1.0
        // Nota: isName("Attack") debe coincidir exactamente con el nombre del estado en el Animator Controller
        if (stateInfo.IsName("Attack") && stateInfo.normalizedTime >= 1.0f)
        {
            // Volver al estado Idle
            context.StateMachine.ChangeState(context.IdleState);
        }


        //version con hash, usar el mismo animator string to hash
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 2. Comparamos el hash del estado actual con el hash de nuestro estado de ataque
        if (stateInfo.shortNameHash == AttackStateHash && stateInfo.normalizedTime >= 1.0f)
        {
            context.StateMachine.ChangeState(context.IdleState);
        }


        //eliminar estos
        t -= dt;

        if (t <= 0f)
        {
            _context.FSM.Change(_context.States.ActionIdle);            
        }
    }

    public void Exit() { } 
}
