using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController _controller;
    public Vector3 DesiredVelocity;
    public Vector3 FacingDir = Vector3.forward;
    public float MoveSpeed = 6f;

    public void Move(Vector3 movement)
    {
        _controller.Move(movement * Time.deltaTime);
    }

    public void FaceTo(Vector3 direction)
    {
        
    }
}
