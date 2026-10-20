using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    static readonly int Speed = Animator.StringToHash("Speed");
    static readonly int Dash = Animator.StringToHash("Dash");
    static readonly int Jump = Animator.StringToHash("Jump");
    static readonly int Attack = Animator.StringToHash("Attack");
    static readonly int Hurt = Animator.StringToHash("Hurt");
    static readonly int Die = Animator.StringToHash("Die");

    [SerializeField] Animator _animator;

    public void UpdateSpeed(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }

    public void StartDash()
    {
        _animator.SetTrigger(Dash);
    }

    public void StartJump()
    {
        _animator.SetTrigger(Jump);
    }

    public void StartAttack()
    {
        _animator.SetTrigger(Attack);
    }

    public void StartHurt()
    {
        _animator.SetTrigger(Hurt);
    }

    public void StartDie()
    {
        _animator.SetTrigger(Die);
    }
}
