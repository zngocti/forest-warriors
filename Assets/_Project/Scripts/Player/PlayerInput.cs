using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector3 MoveDir, FaceDir;
    public bool DashPressed, JumpPressed, AttackPressed, InteractPressed;
    Camera _camera;

    bool _usingMouse = true;

    public void Awake()
    {
        _camera = Camera.main;
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
            FaceDir = screenDirection.normalized;
        }

        return FaceDir;
    }
}
