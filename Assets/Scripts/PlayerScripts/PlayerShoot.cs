using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Weapon _defaultWeapon;
    [SerializeField] Transform _spawnPoint;

    Weapon _currentWeapon;

    void Start()
    {
        SetWeapon(_defaultWeapon);
    }

    public void SetWeapon(Weapon weapon)
    {
        if (_currentWeapon != null) 
            _currentWeapon.DestroyWeapon();

        _currentWeapon = weapon;
        _currentWeapon.Spawn(_spawnPoint);
        _currentWeapon.Shoot();
    }

    public Weapon GetWeapon()
    {
        return _currentWeapon;
    }
}
