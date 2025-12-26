using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _chaseDistance = 10f;
    private EntityMovement _movement;
    private GameObject _player;
    private Rigidbody2D _rb;
    private Transform _playerTransform;

    private void Awake()
    {
        _movement = GetComponent<EntityMovement>();
        _rb = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
        if (_player)
        {
            _playerTransform = _player.transform; 
        }
    }

    void Update()
    {
        if (_player == null || _movement == null) return;

        Vector2 Direction = _playerTransform.position - _rb.transform.position;
        if (Direction.magnitude <= _chaseDistance)
        {
            _movement.Move(Direction);
            _movement.SetLookTarget(_playerTransform.position);
        }
        else
        {
            _movement.Move(Vector2.zero);
        }

    }


}
