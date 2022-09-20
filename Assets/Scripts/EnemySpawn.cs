using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _parent;
    [SerializeField] int _enemyCount;
    [SerializeField] float _spawnCooldown;

    Vector3 _spawnPos;

    float _enemyScaleX;
    float _spawnOffset;
    float firstElementPosition;

    private void Start()
    {
        _enemyScaleX = _enemyPrefab.transform.localScale.x;
        _spawnOffset = _enemyScaleX / 2;
        firstElementPosition = -_enemyScaleX * _enemyCount / 2 + _spawnOffset;
        _spawnPos = new Vector3(firstElementPosition, 0, 20);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity, _parent);
                _spawnPos.x += _enemyScaleX;
            }

            _spawnPos.x = firstElementPosition;

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }
}
