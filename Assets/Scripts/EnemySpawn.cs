using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] int _enemyCount;

    Vector3 _spawnPos;

    float _enemyScaleX;

    private void Start()
    {
        _enemyScaleX = _enemyPrefab.transform.localScale.x;
        _spawnPos = new Vector3(-_enemyScaleX * _enemyCount/2, 0, 20);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            for (int i = 0; i < _enemyCount; i++)
            {
                Instantiate(_enemyPrefab, _spawnPos, Quaternion.identity);
                _spawnPos.x += _enemyScaleX;
            }

            _spawnPos.x = -_enemyScaleX * _enemyCount/2;

            yield return new WaitForSeconds(5f);
        }
    }
}
