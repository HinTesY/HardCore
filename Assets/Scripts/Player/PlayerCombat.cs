using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField]private InputReader _input;
    private float _nextFireTime;

    private void Update()
    {
        if (_input.IsShooting && Time.time >= _nextFireTime)
        {
            Shoot();
            _nextFireTime = Time.time + (1f / _fireRate);
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }
}
