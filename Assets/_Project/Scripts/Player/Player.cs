using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController cc;
    public Animator anim;
    public Vector2 MoveInput;                 // lo llena tu Input System
    public bool dashPressed, attackPressed, interactPressed;

    public AttackData attackData;
    public LayerMask interactMask;
    public Vector3 AimDirection => transform.forward; // luego lo cambias por mouse o stick

    public DamageInfo LastDamage { get; private set; }
    public event System.Action Died;

    public StateMachine<Player> Locomotion = new();
    public StateMachine<Player> Action = new();

    public GroundedState grounded;
    public DashState dash;
    public HurtState hurt;
    public DeadState dead;
    public NoneAction none;
    public AttackAction attack;
    public InteractAction interact;

    public bool IsDead { get; private set; }
    public bool MovementLocked => Action.Current is ActionState a && a.LocksMovement;
    public bool CanStartAction => !IsDead && Locomotion.Current == grounded && Action.Current == none;
    public float MoveSpeedMultiplier =>
        (Action.Current as ActionState)?.MoveSpeedMultiplier ?? 1f;


    void Awake()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        grounded = new GroundedState(this); dash = new DashState(this);
        hurt = new HurtState(this);         dead = new DeadState(this);
        none = new NoneAction(this);        attack = new AttackAction(this);
        interact = new InteractAction(this);
        Locomotion.Change(grounded);
        Action.Change(none);
    }

    void Update()
    {
        Action.Tick(Time.deltaTime);      // primero decide si bloquea
        Locomotion.Tick(Time.deltaTime);  // y este es el ÚNICO que llama cc.Move
    }

    public void TakeDamage(DamageInfo d, bool lethal)
    {
        if (IsDead) return;
        LastDamage = d;

        if (lethal)
        {
            IsDead = true;
            Action.Change(none);
            Locomotion.Change(dead);
            Died?.Invoke();
            return;
        }
        if (d.interruptsAction) Action.Change(none);
        if (d.interruptsMovement) Locomotion.Change(hurt);
    }

    public void Revive()
    {
        IsDead = false;
        Locomotion.Change(grounded);
    }

    public bool TryStartInteract()
    {
        var hits = Physics.OverlapSphere(
            transform.position + transform.forward, 1.5f, interactMask);

        foreach (var h in hits)
        {
            var target = h.GetComponentInParent<IInteractable>();
            if (target != null && target.CanInteract(this))
            {
                interact.SetTarget(target);
                Action.Change(interact);
                return true;
            }
        }
        return false;
    }
}
