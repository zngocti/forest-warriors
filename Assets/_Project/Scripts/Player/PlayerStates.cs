public sealed class PlayerStates
{
    public LocomotionState Locomotion { get; private set; }
    public DashState Dash  { get; private set; }
    public HurtState Hurt { get; private set; }
    public DeadState Dead { get; private set; }
    public ActionIdleState ActionIdle { get; private set; }
    public AttackState Attack { get; private set; }
    public InteractState Interact { get; private set; }
    public JumpState Jump { get; private set; }

    public PlayerStates(Player context)
    {
        Locomotion = new LocomotionState(context);
        Dash = new DashState(context);
        Hurt = new HurtState(context);
        Dead = new DeadState(context);
        ActionIdle = new ActionIdleState(context);
        Attack = new AttackState(context);
        Interact = new InteractState(context);
        Jump = new JumpState(context);
    }
}