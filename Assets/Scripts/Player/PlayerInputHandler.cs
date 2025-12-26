using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private Camera _camera;
    private EntityMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<EntityMovement>();
        if (_camera == null) _camera = Camera.main;
    }

    private void Update()
    {
        _movement.SetMoveInput(_input.MoveDirection);

        Vector2 mousePos = _input.MousePosition;
        Vector2 worldMousePos = _camera.ScreenToWorldPoint(mousePos);
        _movement.SetLookTarget(worldMousePos);
    }
}
