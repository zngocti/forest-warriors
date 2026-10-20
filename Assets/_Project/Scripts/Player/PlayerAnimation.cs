using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    static public readonly int ParameterSpeed = Animator.StringToHash("PSpeed");
    static public readonly int ParameterDash = Animator.StringToHash("PDash");
    static public readonly int ParameterJump = Animator.StringToHash("PJump");
    static public readonly int ParameterAttack = Animator.StringToHash("PAttack");
    static public readonly int ParameterHurt = Animator.StringToHash("PHurt");
    static public readonly int ParameterDie = Animator.StringToHash("PDie");
    static public readonly int StateAttack = Animator.StringToHash("Attack");
    static public readonly int StateHurt = Animator.StringToHash("Hurt");

    [SerializeField] Animator _animator;

    public void UpdateSpeed(float speed)
    {
        _animator.SetFloat(ParameterSpeed, speed);
    }

    public void StartDash()
    {
        _animator.SetTrigger(ParameterDash);
    }

    public void StartJump()
    {
        _animator.SetTrigger(ParameterJump);
    }

    public void StartAttack()
    {
        _animator.SetTrigger(ParameterAttack);
    }

    public void StartHurt()
    {
        _animator.SetTrigger(ParameterHurt);
    }

    public void StartDie()
    {
        _animator.SetTrigger(ParameterDie);
    }

    public bool GetNormalizedTime(int stateHash, out float normalizedTime)
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.shortNameHash == stateHash)
        {
            normalizedTime = stateInfo.normalizedTime;
            return true;
        }

        normalizedTime = -1;
        return false;
    }
}
