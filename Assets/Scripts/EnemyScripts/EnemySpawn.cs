using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] Transform _parent;
    [SerializeField] Vector2 _spawnCooldown;

    Vector3 _spawnPos;
    Dictionary<int, Vector3> _enemySpawn = new Dictionary<int, Vector3>();

    [SerializeField] int _enemyCount;
    float _enemyScaleX;
    float _spawnOffset;
    float firstElementPosition;

    private void Start()
    {
        Camera camera = Camera.main;

        Vector3 worldBottomCoords = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.transform.position.y));

        float screenWide = -worldBottomCoords.x * 2;

        _enemyScaleX = _enemyPrefab.transform.localScale.x;
        _spawnOffset = _enemyScaleX / 2;
        _enemyCount = Mathf.CeilToInt(screenWide / _enemyScaleX * 1.2f);
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
            int direction = Random.Range(-1, 2);
            for (int i = 0; i < enemyCount; i++)
            {
                int spawnIndex = Random.Range(0, _enemyCount);

                if (!isSpawned.Contains(spawnIndex))
                {
                    var cube = Instantiate(_enemyPrefab, _enemySpawn[spawnIndex], Quaternion.identity, _parent);
                    cube.GetComponent<EnemyMovement>().SetDirection(direction);
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

    private void OnDisable()
    {
        ScoreCounter.onScoreEvent -= StopSpawn;
    }
}
