using UnityEngine;

public class Projectile : MonoBehaviour
{
    float _speed;
    float _projectileDamage;

    public void SetStats(float speed, float damage)
    {
        _speed = speed;
        _projectileDamage = damage;
    }    

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyhp = other.gameObject.GetComponent<EnemyHP>();

        if (enemyhp != null)
        {
            enemyhp.ApplyDamage(_projectileDamage);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
