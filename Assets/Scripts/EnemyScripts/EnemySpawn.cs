using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _parent;
    [SerializeField] int _enemyCount;
    [SerializeField] Vector2 _spawnCooldown;

    Vector3 _spawnPos;
    Dictionary<int, Vector3> _enemySpawn = new Dictionary<int, Vector3>();

    float _enemyScaleX;
    float _spawnOffset;
    float firstElementPosition;

    private void Start()
    {
        _enemyScaleX = _enemyPrefab.transform.localScale.x;
        _spawnOffset = _enemyScaleX / 2;
        firstElementPosition = -_enemyScaleX * _enemyCount / 2 + _spawnOffset;
        _spawnPos = new Vector3(firstElementPosition, 0, 25);

        ScoreCounter.onScoreEvent += StopSpawn;

        SetSpawnpointDictionary();
        StartSpawn();
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            List<int> isSpawned = new List<int>();

            int enemyCount = Random.Range(1, _enemyCount);

            for (int i = 0; i < enemyCount; i++)
            {
                int spawnIndex = Random.Range(0, _enemyCount);

                if (!isSpawned.Contains(spawnIndex))
                {
                    Instantiate(_enemyPrefab, _enemySpawn[spawnIndex], Quaternion.identity, _parent);
                    isSpawned.Add(spawnIndex);
                }
            }

            isSpawned.Clear();

            float waitTime = Random.Range(_spawnCooldown.x, _spawnCooldown.y);

            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SetSpawnpointDictionary()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            _enemySpawn.Add(i, _spawnPos);
            _spawnPos.x += _enemyScaleX;
        }
    }
}
