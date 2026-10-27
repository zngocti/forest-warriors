using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    [SerializeField] float _moveSpeed = 6f;
    [SerializeField] float _rotationSpeed = 15f;
    Camera _mainCamera;
    public Vector3 FacingDir { get => Vector3.forward; }

    void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void Move(Vector3 movement, bool applyPlayerSpeed)
    {
        if (applyPlayerSpeed)
        {
            _controller.Move(movement * _moveSpeed * Time.deltaTime);             
        }
        else
        {
            _controller.Move(movement * Time.deltaTime); 
        }
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
