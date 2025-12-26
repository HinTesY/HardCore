using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private Health _health;

    void Awake()
    {
        if (_health == null) _health = GetComponent<Health>();
    }
    private void OnEnable()
    {
        _health.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        _health.OnDeath -= HandleDeath;
    }

    void HandleDeath()
    {
        Destroy(gameObject);
    }
}
