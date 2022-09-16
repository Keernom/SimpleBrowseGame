using UnityEngine;
using UnityEngine.Events;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] float _health = 1;
    public float Health { get { return _health; } }

    public UnityAction OnHit;

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
        {
            Destroy(gameObject);
        }

        OnHit?.Invoke();
    }
}
