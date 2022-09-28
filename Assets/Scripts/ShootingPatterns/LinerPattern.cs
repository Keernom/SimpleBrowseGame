using System.Collections;
using UnityEngine;

public class LinerPattern : MonoBehaviour, IShootable
{
    IEnumerator Shooting()
    {
        Weapon weapon = transform.parent.GetComponent<PlayerShoot>().GetWeapon();
        GameObject _projectilePrefab = weapon.GetProjectile;
        
        while (true)
        {
            Vector3 position = transform.position;
            position.z += 3;
            var a = Instantiate(_projectilePrefab, position, Quaternion.identity);
            a.GetComponent<Projectile>().SetStats(Vector3.forward, weapon.GetSpeed, weapon.GetDamage);
            yield return new WaitForSeconds(weapon.GetFireRate);
        }
    }

    public void Shoot()
    {
        StartCoroutine(Shooting());
    }

    public void StopShoot()
    {
        StopAllCoroutines();
    }
}
