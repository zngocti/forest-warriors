using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController _characterController;
    [SerializeField] float _movementSpeed = 5;
    Vector2 _movementInput;

    void Update()
    {
        MovePlayer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<Vector2>();
    }

    void MovePlayer()
    {
        Vector3 movement = new Vector3(_movementInput.x, 0, _movementInput.y) * _movementSpeed * Time.deltaTime;
        _characterController.Move(movement);
    }
}
