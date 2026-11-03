using UnityEngine;

public enum SpeedMode
{
    Replace,
    Add,
    Multiply,
    Ignore
} 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    [SerializeField] float _moveSpeed = 6f;
    [SerializeField] float _rotationSpeed = 15f;
    [SerializeField] float _gravity = -15f;
    Camera _mainCamera;
    public Vector3 FacingDir { get => transform.forward; }
    public float Gravity { get => _gravity; }
    public bool OnFloor { get => false; }

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void Move(Vector3 movement, SpeedMode playerSpeedMode, SpeedMode gravityMode, bool impulse = false)
    {
        switch (gravityMode)
        {
            case SpeedMode.Replace:
                movement.y = _gravity;
                break;
            case SpeedMode.Add:
                movement.y += _gravity;
                break;
            case SpeedMode.Multiply:
                movement.y *= _gravity;
                break;
            case SpeedMode.Ignore:
                break;
            default:
                break;
        }

        switch (playerSpeedMode)
        {
            case SpeedMode.Replace:
                movement.x = _moveSpeed;
                movement.z = _moveSpeed;
                break;
            case SpeedMode.Add:
                movement.x += _moveSpeed;
                movement.z += _moveSpeed;
                break;
            case SpeedMode.Multiply:
                movement.x *= _moveSpeed;
                movement.z *= _moveSpeed;
                break;
            case SpeedMode.Ignore:
                break;
            default:
                break;
        }

        _controller.Move(movement * (impulse ? 1 : Time.deltaTime));
    }

    public void FaceTo(Vector3 direction)
    {
        if (direction == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);        
    }
}
