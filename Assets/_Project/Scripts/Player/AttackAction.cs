using UnityEngine;

public class AttackAction : ActionState
{
    public AttackAction(Player p) : base(p) { }

    float t;
    bool fired;
    AttackData Data => c.attackData;

    public override float MoveSpeedMultiplier => Data.moveSpeedMultiplier;

    public override void Enter()
    {
        t = 0;
        fired = false;
        c.anim.SetTrigger("Attack");
    }

    public override void Tick(float dt)
    {
        t += dt;

        if (!fired && t >= Data.fireTime)
        {
            fired = true;
            Fire();
        }

        if (t >= Data.duration)
            c.Action.Change(c.none);
    }

    void Fire()
    {
        Vector3 dir = c.AimDirection;
        Vector3 origin = c.transform.position + Vector3.up + dir * 0.8f;
        Object.Instantiate(Data.projectilePrefab, origin, Quaternion.LookRotation(dir));
    }

    public override void Exit()
    {
        c.anim.ResetTrigger("Attack");
    }
}
