using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotPattern : MonoBehaviour, IShootPattern
{
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(.5f);

        Weapon weapon = transform.parent.GetComponent<PlayerShooting>().GetWeapon();
        GameObject _projectilePrefab = weapon.GetProjectile;
        
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 position = transform.GetChild(i).position;
                position.z += 2;
                var a = Instantiate(_projectilePrefab, position, Quaternion.identity);
                a.GetComponent<Projectile>().SetStats(weapon.GetSpeed, weapon.GetDamage);
                print(weapon.GetDamage);
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
