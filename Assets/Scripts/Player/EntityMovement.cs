using UnityEngine;

public class EntityMovement : MonoBehaviour, IControllable
{
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotationSpeed = 720f;
    
    private Health _health;
    private Rigidbody2D _rb;
    
    private Vector2 _moveInput;
    private Vector2 _lookTarget;
    private bool _hasLookTarget;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        ApplyMove(_moveInput);
        if (_hasLookTarget)
        {
            ApplyRotation(_lookTarget);
        }
    }

    private void OnEnable()
    {
        if (_health != null) _health.OnDeath += DisableMovement;
    }

    private void OnDisable()
    {
        if (_health != null) _health.OnDeath -= DisableMovement;
    }

    private void DisableMovement()
    {
        if (_rb != null) _rb.linearVelocity = Vector2.zero;
        this.enabled = false;
    }

    public void SetMoveInput(Vector2 direction)
    {
        _moveInput = direction;
    }

    public void SetLookTarget(Vector2 targetPosition)
    {
        _lookTarget = targetPosition;
        _hasLookTarget = true;
    }

    private void ApplyRotation(Vector2 targetPos)
    {
        Vector2 direction = targetPos - _rb.position;
        
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = _rb.rotation;
        
        float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, _rotationSpeed * Time.fixedDeltaTime);
        
        _rb.MoveRotation(newAngle);
    }

    private void ApplyMove(Vector2 direction)
    {
        _rb.linearVelocity = direction.normalized * _moveSpeed;
    }

    public void Move(Vector2 direction)
    {
        SetMoveInput(direction);
    }
}
