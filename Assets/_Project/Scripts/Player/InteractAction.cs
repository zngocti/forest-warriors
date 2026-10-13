using UnityEngine;

public class InteractAction : ActionState
{
    public InteractAction(Player p) : base(p) { }

    IInteractable target;
    bool finished;

    public override bool LocksMovement => true;

    public void SetTarget(IInteractable t) => target = t;

    public override void Enter()
    {
        finished = false;
        c.anim.SetBool("Interacting", true);
        target.BeginInteract(c, OnFinished);
    }

    void OnFinished()
    {
        // Ignora llamadas tardías si la interacción ya fue cortada
        if (c.Action.Current != this) return;
        finished = true;
        c.Action.Change(c.none);
    }

    public override void Exit()
    {
        c.anim.SetBool("Interacting", false);

        // Si salimos sin terminar, fue una interrupción: avisa al NPC
        if (!finished) target?.CancelInteract(c);
        target = null;
    }
}
