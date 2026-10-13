using UnityEngine;

public class JumpState : State<Player>
{
    public JumpState(Player p) : base(p) { }
    Vector3 dir; float t;
    const float Duration = 0.25f, Speed = 14f;
    //agregar altura, duracion, velocidad
    public override void Enter()
    {
        dir = c.transform.forward;       // o la dirección del input
        t = 0;
        c.anim.SetTrigger("Dash");
    }
    public override void Tick(float dt)
    {
        c.cc.Move(dir * Speed * dt);
        t += dt;
        if (t >= Duration) c.Locomotion.Change(c.grounded);
    }
}
