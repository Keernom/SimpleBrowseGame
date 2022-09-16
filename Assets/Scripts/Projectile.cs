using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _damage;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemyhp = other.gameObject.GetComponent<EnemyHP>();
        if (enemyhp != null)
        {
            enemyhp.ApplyDamage(_damage);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
