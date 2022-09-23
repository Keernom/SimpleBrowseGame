using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject _weaponPrefab;
    [SerializeField] GameObject _projectilePrefab;

    [SerializeField] int _weaponDamage;
    [SerializeField] float _fireRate;
    [SerializeField] float _projectileSpeed;

    private GameObject weapon;

    public int GetDamage { get { return _weaponDamage; } }
    public float GetSpeed { get { return _projectileSpeed; } }
    public float GetFireRate { get { return 1/_fireRate; } }

    public GameObject GetProjectile { get { return _projectilePrefab; } }
    

    public void Spawn(Transform spawnPoint)
    {
        weapon = Instantiate(_weaponPrefab, spawnPoint);
        
    }

    public void Shoot()
    {
        weapon.GetComponent<IShootable>().Shoot();
    }

    public void DestroyWeapon()
    {
        weapon.GetComponent<IShootable>().StopShoot();
        Destroy(weapon);
    }

    public GameObject GetWeapon()
    {
        return weapon;
    }
}
