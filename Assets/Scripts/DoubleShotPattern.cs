using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPattern : MonoBehaviour, IShootable
{
    IEnumerator Shooting()
    {
        Weapon weapon = transform.parent.GetComponent<PlayerShoot>().GetWeapon();
        GameObject _projectilePrefab = weapon.GetProjectile;
        
        while (true)
        {
            print(this + " " + weapon.GetDamage);
            for (int i = 0; i < 2; i++)
            {
                Vector3 position = transform.GetChild(i).position;
                position.z += 2;
                var a = Instantiate(_projectilePrefab, position, Quaternion.identity);
                a.GetComponent<Projectile>().SetStats(weapon.GetSpeed, weapon.GetDamage);
            }
            
            yield return new WaitForSeconds(weapon.GetFireRate);
        }
    }

    public void Shoot()
    {
        StartCoroutine(Shooting());
    }

    public void StopShoot()
    {
        StopCoroutine(Shooting());
    }
}
