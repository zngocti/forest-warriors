using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    Vector3 _moveDir = Vector3.zero;
    Vector3 _faceDir = Vector3.zero;
    bool _dashPressed = false;
    bool _jumpPressed = false;
    bool _attackPressed = false;
    bool _interactPressed = false;
    Camera _camera;
    bool _usingMouse = true;

    public Vector3 MoveDir { private set => _moveDir = value; get => _moveDir; }
    public Vector3 FaceDir { private set => _faceDir = value; get => _faceDir; }
    public bool DashPressed { private set => _dashPressed = value; get => _dashPressed; }
    public bool JumpPressed { private set => _jumpPressed = value; get => _jumpPressed; }
    public bool AttackPressed { private set => _attackPressed = value; get => _attackPressed; }
    public bool InteractPressed { private set => _interactPressed = value; get => _interactPressed; }

    public void Awake()
    {
        _camera = Camera.main;
    }

    public void ConsumeDash()
    {
        DashPressed = false;
    }

    public void ConsumeJump()
    {
        JumpPressed = false;
    }

    public void ConsumeAttack()
    {
        AttackPressed = false;
    }

    public void ConsumeInteraction()
    {
        InteractPressed = false;
    }

    public Vector3 GetFaceDirRelativeTo(Vector3 pos)
    {
        if (!_usingMouse)
        {
            return FaceDir;
        }

        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector2 targetScreenPos = _camera.WorldToScreenPoint(pos);
        Vector2 screenDirection = mouseScreenPos - targetScreenPos;

        if (screenDirection.sqrMagnitude > 0.01f)
        {
            Vector2 normalized = screenDirection.normalized;
            FaceDir = new Vector3(normalized.x, 0, normalized.y);
        }

        return FaceDir;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        MoveDir = new Vector3(dir.x, 0, dir.y);
    }

    public void OnFaceAt(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        FaceDir = new Vector3(dir.x, 0, dir.y);
    }

    public void OnDashPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DashPressed = true;
        }
        else if (context.canceled)
        {
            DashPressed = false;
        }
    }

    public void OnJumpPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpPressed = true;
        }
        else if (context.canceled)
        {
            JumpPressed = false;
        }
    }

    public void OnAttackPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackPressed = true;
        }
        else if (context.canceled)
        {
            AttackPressed = false;
        }
    }

    public void OnInteractPressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractPressed = true;
        }
        else if (context.canceled)
        {
            InteractPressed = false;
        }
    }
}
