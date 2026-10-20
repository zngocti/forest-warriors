using UnityEngine;

public class HurtState : IState
{
    readonly Player _context;
    float t;
    public HurtState(Player context)
    {
        _context = context;
    }

    public void Enter() { t = 0.35f; c.Animator.SetTrigger("Hurt"); }
    public void Tick(float dt)
    {
        t -= dt;
        if (t <= 0f) c.Body.Change(c.States.Locomotion);
    }
    public void Exit() { }
}
