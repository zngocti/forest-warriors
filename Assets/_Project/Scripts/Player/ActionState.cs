using UnityEngine;

public abstract class ActionState : State<Player>
{
    protected ActionState(Player p) : base(p) { }
    public virtual bool LocksMovement => false;
    public virtual float MoveSpeedMultiplier => 1f;
}
