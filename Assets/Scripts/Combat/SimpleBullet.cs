using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _damage = 10f;

    private Rigidbody2D _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (_rb)
        {
            _rb.linearVelocity = transform.right * _speed;
        }
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out var damageable)) 
        {
            damageable.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
