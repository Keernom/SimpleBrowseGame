using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem _projectileExplosion;

    Vector3 _direction;
    float _speed;
    float _projectileDamage;

    public void SetStats(Vector3 direction, float speed, float damage)
    {
        _direction = direction;
        _speed = speed;
        _projectileDamage = damage;
    }    

    void Update()
    {
        transform.Translate(_direction * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyhp = other.gameObject.GetComponent<EnemyHP>();
        
        if (enemyhp != null)
        {
            if (enemyhp.Health > 0)
                enemyhp.ApplyDamage(_projectileDamage);
            Destroy(gameObject);
        }
    }

    public void ProjectileExplosion()
    {
        var explosion = Instantiate(_projectileExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
