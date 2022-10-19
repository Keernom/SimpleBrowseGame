using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] List<Pickup> _pickupsList;
    [SerializeField] float _pickupSpeed;

    public float PickupSpeed { get { return _pickupSpeed; } }

    Dictionary<Stats, float> _weaponUpgradeDict = new Dictionary<Stats, float>();

    Vector3 _spawnPos;

    float _pickupsSpawnCount = 3;
    float _pickupScaleX;
    float _firstElementPos;
    int _enemyCount;

    private void Start()
    {
        SpawnPointSetup();

        _weaponUpgradeDict.Add(Stats.Damage, 0);
        _weaponUpgradeDict.Add(Stats.FireRate, 0);
        _weaponUpgradeDict.Add(Stats.ProjectileSpeed, 0);

        _spawnPos = new Vector3(_firstElementPos, 0, 30);

        ScoreCounter.onScoreEvent += UpgradeInitialize;
    }

    private void SpawnPointSetup()
    {
        _pickupScaleX = _pickupsList[1].transform.localScale.x * 3 * 2;
        float _spawnOffset = _pickupScaleX / 2;
        _firstElementPos = -_pickupsSpawnCount * _pickupScaleX / 2 + _spawnOffset;
    }

    void UpgradeInitialize()
    {
        StartCoroutine(CountEnemies());
    }

    void PickupSpawn()
    {
        FindObjectOfType<PlayerShoot>().GetWeapon().StopShoot();

        List<int> spawnedPickups = new List<int>();

        for (int i = 0; i < _pickupsSpawnCount; i++)
        {
            bool isSpawned = false;

            while(!isSpawned)
            {
                int itemIndex = Mathf.FloorToInt(Random.Range(0, _pickupsList.Count));

                if (!spawnedPickups.Contains(itemIndex) && !IsItPlayersWeapon(itemIndex))
                {
                    isSpawned = true;
                    spawnedPickups.Add(itemIndex);
                    Instantiate(_pickupsList[itemIndex], _spawnPos, Quaternion.identity);
                }
            }

            _spawnPos.x += _pickupScaleX;
        }
        spawnedPickups.Clear();
        _spawnPos.x = _firstElementPos;
    }

    private bool IsItPlayersWeapon(int itemIndex)
    {
        return _pickupsList[itemIndex].GetComponent<WeaponPickup>() != null &&
                            FindObjectOfType<PlayerShoot>().GetWeapon() == _pickupsList[itemIndex].GetComponent<WeaponPickup>().GetPickupWeapon;
    }

    public void DestroyAllPickups()
    {
        Pickup[] go = FindObjectsOfType<Pickup>();
        int pickupsCount = go.Length;

        if (pickupsCount > 0)
        {
            for (int i = 0; i < pickupsCount; i++)
            {
                Destroy(go[i].gameObject);
            }

            FindObjectOfType<PlayerShoot>().GetWeapon().Shoot();
            FindObjectOfType<EnemySpawn>().StartSpawn();
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

    public void ClearUpgradeDict()
    {
        _weaponUpgradeDict.Clear();
    }

    IEnumerator CountEnemies()
    {
        _enemyCount = FindObjectsOfType<EnemyHP>().Length;

        while (_enemyCount != 0)
        {
            _enemyCount = FindObjectsOfType<EnemyHP>().Length;
            yield return new WaitForEndOfFrame();
        }

        if (FindObjectOfType<PlayerShoot>() != null)
            PickupSpawn();
    }

    private void OnDisable()
    {
        ScoreCounter.onScoreEvent -= UpgradeInitialize;
    }
}
