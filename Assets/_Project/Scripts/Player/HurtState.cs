using UnityEngine;

public class HurtState : State<Player>
{
    public HurtState(Player p) : base(p) { }

    const float Duration = 0.35f;
    const float KnockbackFriction = 20f;

    float t, vy;
    Vector3 knock;

    public override void Enter()
    {
        t = 0;
        vy = 0;
        knock = c.LastDamage.knockback;
        knock.y = 0;                       // el empuje es horizontal
        c.anim.SetTrigger("Hurt");
    }

    public override void Tick(float dt)
    {
        vy = c.cc.isGrounded ? -2f : vy + Physics.gravity.y * dt;

        c.cc.Move((knock + Vector3.up * vy) * dt);
        knock = Vector3.MoveTowards(knock, Vector3.zero, KnockbackFriction * dt);

        t += dt;
        if (t >= Duration)
            c.Locomotion.Change(c.grounded);
    }

    public override void Exit()
    {
        c.anim.ResetTrigger("Hurt");
    }
}
