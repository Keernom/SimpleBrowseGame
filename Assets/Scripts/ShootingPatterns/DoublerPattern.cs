using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublerPattern : MonoBehaviour, IShootable
{
    IEnumerator Shooting()
    {
        AudioSource audioSource = transform.parent.GetComponent<AudioSource>();
        Weapon weapon = transform.parent.GetComponent<PlayerShoot>().GetWeapon();
        GameObject _projectilePrefab = weapon.GetProjectile;
        
        while (true)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector3 position = transform.GetChild(i).position;
                position.z += 1.5f;
                var a = Instantiate(_projectilePrefab, position, Quaternion.identity);
                audioSource.PlayOneShot(weapon.GetAudio, 0.01f);
                a.GetComponent<Projectile>().SetStats(Vector3.forward, weapon.GetSpeed, weapon.GetDamage);
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
        StopAllCoroutines();
    }
}
