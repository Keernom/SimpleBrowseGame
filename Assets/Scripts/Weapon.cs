using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
public class Weapon : ScriptableObject
{
    [SerializeField] GameObject _weaponPrefab;
    [SerializeField] GameObject _projectilePrefab;

    [SerializeField] float _weaponDamage;
    [SerializeField] float _projectileSpeed;

    private GameObject weapon;

    public float GetDamage { get { return _weaponDamage; } }
    public float GetSpeed { get { return _projectileSpeed; } }

    public GameObject GetProjectile { get { return _projectilePrefab; } }
    

    public void Spawn(Transform spawnPoint)
    {
        weapon = Instantiate(_weaponPrefab, spawnPoint);
        
    }

    public void Shoot()
    {
        weapon.GetComponent<IShootPattern>().Shoot();
    }

    public void DestroyWeapon()
    {
        weapon.GetComponent<IShootPattern>().StopShoot();
        Destroy(weapon);
    }

    public GameObject GetWeapon()
    {
        return weapon;
    }
}
