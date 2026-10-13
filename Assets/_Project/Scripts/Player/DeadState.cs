using UnityEngine;

public class DeadState : State<Player>
{
    public DeadState(Player p) : base(p) { }

    float vy;

    public override void Enter()
    {
        vy = 0;
        c.anim.SetBool("Dead", true);
    }

    public override void Tick(float dt)
    {
        // Sin input; solo cae si murió en el aire
        vy = c.cc.isGrounded ? -2f : vy + Physics.gravity.y * dt;
        c.cc.Move(Vector3.up * vy * dt);
    }

    public override void Exit()
    {
        // Solo se ejecuta si llamas a Revive()
        c.anim.SetBool("Dead", false);
    }
}
