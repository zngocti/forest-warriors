using UnityEngine;

public class GroundedState : State<Player>
{
    public GroundedState(Player p) : base(p) { }
    float vy;

    public override void Tick(float dt)
    {
        vy = c.cc.isGrounded ? -2f : vy + Physics.gravity.y * dt;

        Vector3 dir = Vector3.zero;
        if (!c.MovementLocked)
            dir = new Vector3(c.MoveInput.x, 0, c.MoveInput.y).normalized;

        // En isométrica, rota dir según el ángulo de la cámara aquí
        c.cc.Move((dir * 5f * c.MoveSpeedMultiplier + Vector3.up * vy) * dt);
        if (dir != Vector3.zero)
            c.transform.rotation = Quaternion.LookRotation(dir);

        c.anim.SetFloat("Speed", dir.magnitude, 0.1f, dt);

        if (c.CanStartAction)
        {
            if (c.dashPressed) { c.dashPressed = false; c.Locomotion.Change(c.dash); }
            else if (c.attackPressed) { c.attackPressed = false; c.Action.Change(c.attack); }
            else if (c.interactPressed && c.MoveInput == Vector2.zero)
            { c.interactPressed = false; c.Action.Change(c.interact); }
        }
        else if (c.interactPressed && c.MoveInput == Vector2.zero)
        {
            c.interactPressed = false;
            c.TryStartInteract();
        }
    }
}
