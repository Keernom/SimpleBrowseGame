using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyHP _enemyHP;

    int _currentDamage;

    private void Start()
    {
        _currentDamage = _enemyHP.Health;
    }

    private void OnEnable()
    {
        _enemyHP = transform.GetComponent<EnemyHP>();
        _enemyHP.OnHit += DamageUpdate;
    }

    void DamageUpdate()
    {
        _currentDamage = _enemyHP.Health;
    }

    private void OnDisable()
    {
        _enemyHP.OnHit -= DamageUpdate;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHP>().ApplyDamage(_currentDamage);
            Destroy(gameObject);
        }
    }
}
