using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerMovement _movement;
    [SerializeField] PlayerAnimation _animation;
    [SerializeField] PlayerInput _input;
    StateMachine _stateMachine = new StateMachine();
    PlayerStates _states;

    GameObject _interactionTarget;

    bool _canJump = true;
    bool _canDash = true;

    public int Health = 100;

    public PlayerMovement Movement { get => _movement; }
    public PlayerAnimation Animation { get => _animation; }
    public PlayerInput Input { get => _input; }
    public StateMachine FSM { get => _stateMachine; }
    public PlayerStates States { get => _states; }
    public GameObject InteractionTarget { get => _interactionTarget; }
    public bool CanJump { get => _canJump; }
    public bool CanDash { get => _canDash; }

    void Awake()
    {
        _states = new PlayerStates(this);
    }
}
