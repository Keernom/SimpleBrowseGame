using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] float _firstPickupScores;
    [SerializeField] float _pickupsSpawnCount;
    [SerializeField] List<GameObject> _pickupsList;

    ScoreCounter _scoreCounter;

    Vector3 _spawnPos;

    float _currentPickupScores;

    float _spawnOffset;
    float _pickupScaleX;
    float _firstElementPos;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        _currentPickupScores = _firstPickupScores;
        _pickupScaleX = _pickupsList[1].transform.localScale.x;
        _spawnOffset = _pickupScaleX / 2;
        _firstElementPos = -_pickupsSpawnCount * _pickupScaleX / 2 + _spawnOffset;

        _spawnPos = new Vector3(_firstElementPos, 0, 0);
    }

    private void Update()
    {
        if (_scoreCounter.Scores >= _currentPickupScores)
        {
            for (int i = 0; i < _pickupsSpawnCount; i++)
            {
                int itemIndex = Mathf.FloorToInt(Random.Range(0,_pickupsList.Count));

                Instantiate(_pickupsList[itemIndex], _spawnPos, Quaternion.identity);

                _spawnPos.x += _pickupScaleX;
            }

            _spawnPos.x = _firstElementPos;
            _currentPickupScores *= 1.5f;
        }
    }
}
