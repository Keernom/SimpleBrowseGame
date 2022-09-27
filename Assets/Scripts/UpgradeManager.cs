using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] List<Pickup> _pickupsList;
    [SerializeField] float _firstPickupScores;
    [SerializeField] float _pickupsSpawnCount;
    [SerializeField] float _pickupLifeTime;

    public float PickUpLifeTime { get { return _pickupLifeTime; } }

    Dictionary<Stats, float> _weaponUpgradeDict = new Dictionary<Stats, float>();
    ScoreCounter _scoreCounter;

    Vector3 _spawnPos;

    float _pickupScaleX;
    float _firstElementPos;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();

        _pickupScaleX = _pickupsList[1].transform.localScale.x;
        float _spawnOffset = _pickupScaleX / 2;
        _firstElementPos = -_pickupsSpawnCount * _pickupScaleX / 2 + _spawnOffset;

        _weaponUpgradeDict.Add(Stats.Damage, 0);
        _weaponUpgradeDict.Add(Stats.FireRate, 0);
        _weaponUpgradeDict.Add(Stats.ProjectileSpeed, 0);

        _spawnPos = new Vector3(_firstElementPos, 0, 0);

        _scoreCounter.onScoreEvent += PickupSpawn;
    }

    void PickupSpawn()
    {
        List<int> spawnedPickups = new List<int>();

        for (int i = 0; i < _pickupsSpawnCount; i++)
        {
            bool isSpawned = false;

            while(!isSpawned)
            {
                int itemIndex = Mathf.FloorToInt(Random.Range(0, _pickupsList.Count));
                if (!spawnedPickups.Contains(itemIndex))
                {
                    isSpawned = true;
                    spawnedPickups.Add(itemIndex);
                    Instantiate(_pickupsList[itemIndex], _spawnPos, Quaternion.identity);
                }   
            }
            _spawnPos.x += _pickupScaleX + 1;
        }
        spawnedPickups.Clear();
        _spawnPos.x = _firstElementPos;
    }

    public void DestroyAllPickups()
    {
        Pickup[] go = FindObjectsOfType<Pickup>();
        int pickupsCount = go.Length;

        for (int i = 0; i < pickupsCount; i++)
        {
            Destroy(go[i].gameObject);
        }
    }

    public void AddInfoToUpgrade(Stats stat, float value)
    {
        _weaponUpgradeDict[stat] += value;
    }

    public void ApplyAllUpgrades()
    {
        Weapon weapon = FindObjectOfType<PlayerShoot>().GetWeapon();
        
        foreach (var a in _weaponUpgradeDict.Keys)
        {
            weapon.UpdateStat(a, _weaponUpgradeDict[a]);
        }
    }
}
