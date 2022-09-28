using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject _weaponPrefab;
    [SerializeField] GameObject _projectilePrefab;

    [SerializeField] float _weaponDamage;
    [SerializeField] float _fireRate;
    [SerializeField] float _projectileSpeed;

    private GameObject weapon;
    private Dictionary<Stats, float> _statsDict = new Dictionary<Stats, float>();
    private Dictionary<Stats, float> _defaultStatsDict = new Dictionary<Stats, float>();

    public GameObject GetProjectile { get { return _projectilePrefab; } }

    public float GetDamage { get { return _statsDict[Stats.Damage]; } }
    public float GetSpeed { get { return _statsDict[Stats.ProjectileSpeed]; } }
    public float GetFireRate { get { return 1/_statsDict[Stats.FireRate]; } }

    public void Spawn(Transform spawnPoint)
    {
        StatsDictionarySetup();
        weapon = Instantiate(_weaponPrefab, spawnPoint);
    }

    private void StatsDictionarySetup()
    {
        _defaultStatsDict.Add(Stats.Damage, _weaponDamage);
        _defaultStatsDict.Add(Stats.FireRate, _fireRate);
        _defaultStatsDict.Add(Stats.ProjectileSpeed, _projectileSpeed);

        _statsDict.Add(Stats.Damage, _weaponDamage);
        _statsDict.Add(Stats.FireRate, _fireRate);
        _statsDict.Add(Stats.ProjectileSpeed, _projectileSpeed);
    }

    public void Shoot()
    {
        weapon.GetComponent<IShootable>().Shoot();
    }

    public void StopShoot()
    {
        weapon.GetComponent<IShootable>().StopShoot();
    }

    public void DestroyWeapon()
    {
        weapon.GetComponent<IShootable>().StopShoot();
        _defaultStatsDict.Clear();
        _statsDict.Clear();
        Destroy(weapon);
    }

    public void UpdateStat(Stats stat, float valueInPercent)
    {
        _statsDict[stat] += Mathf.CeilToInt(_defaultStatsDict[stat] * valueInPercent);
    }
}
