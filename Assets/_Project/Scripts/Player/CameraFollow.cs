using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float _smoothing = 5f;

    private void LateUpdate()
    {
        if (_target == null)
        {
            return;            
        }

        Vector3 pos = _target.position + _offset;
        pos = Vector3.Lerp(transform.position, pos, _smoothing * Time.deltaTime);
        transform.position = pos;
    }
}
