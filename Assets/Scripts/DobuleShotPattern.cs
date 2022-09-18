using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobuleShotPattern : MonoBehaviour, IShootPattern
{
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(.5f);

        Weapon weapon = transform.parent.GetComponent<PlayerShooting>().GetWeapon();
        GameObject _projectilePrefab = weapon.GetProjectile;
        
        while (true)
        {
            Vector3 position = transform.position;

            for (int i = -1; i < 1; i++)
            {
                position.x += 1;
                var a = Instantiate(_projectilePrefab, position , Quaternion.identity);
                a.GetComponent<Projectile>().SetStats(weapon.GetSpeed, weapon.GetDamage);
                print(weapon.GetDamage);
            }
            
            yield return new WaitForSeconds(.5f);
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
