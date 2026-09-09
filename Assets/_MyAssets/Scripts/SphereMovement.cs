using UnityEngine;
using UnityEngine.InputSystem;

public class SphereMovement : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;
    private Vector3 _direction;
    private float _speed = 10f;

    private void Start() {
        _move.action.performed += MoveSphere;
    }

    private void OnDestroy() {
        _move.action.performed -= MoveSphere;
    }

    private void MoveSphere(InputAction.CallbackContext obj) {
        Vector2 direction2D = obj.ReadValue<Vector2>();
        _direction = new Vector3(direction2D.x, 0, direction2D.y);
        transform.Translate(_direction * _speed * Time.fixedDeltaTime);
    }
}
