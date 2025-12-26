using UnityEngine;

public class PlayerMovement : MonoBehaviour, IControllable
{
    [SerializeField] private InputReader _input;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private Camera _camera;
    private Health _health;
    private Rigidbody2D _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();

    }
    private void FixedUpdate()
    {
        Vector2 currentDirection = _input.MoveDirection;
        Move(currentDirection);
        Rotate();
    }

    private void OnEnable()
    {
        _health.OnDeath += DisableMovement;
    }
    private void OnDisable()
    {
        _health.OnDeath -= DisableMovement;
    }

    private void DisableMovement()
    {
        _rb.linearVelocity = Vector2.zero;
        this.enabled = false;
    }

    private void Rotate()
    {
        Vector2 mousePos = Input.mousePosition;
        bool isMouseScreen = mousePos.x >= 0 && mousePos.y >= 0 && mousePos.x <= Screen.width && mousePos.y <= Screen.height;
        if (!isMouseScreen) return;
        Vector2 playerMouse = _camera.ScreenToWorldPoint(mousePos);
        playerMouse = playerMouse - _rb.position;
        float angle = Mathf.Atan2(playerMouse.y, playerMouse.x) * Mathf.Rad2Deg;
        _rb.MoveRotation(angle);
    }
    public void Move(Vector2 direction)
    {
        _rb.linearVelocity = direction.normalized * _moveSpeed;
    }

}
