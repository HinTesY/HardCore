using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    [SerializeField] private Health _health;

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
