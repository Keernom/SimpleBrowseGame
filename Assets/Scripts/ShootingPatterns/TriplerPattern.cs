using System.Collections;
using UnityEngine;

public class TriplerPattern : MonoBehaviour, IShootable
{
    IEnumerator Shooting()
    {
        AudioSource audioSource = transform.parent.GetComponent<AudioSource>();
        Weapon weapon = transform.parent.GetComponent<PlayerShoot>().GetWeapon();
        GameObject _projectilePrefab = weapon.GetProjectile;

        float projectileScaleX = _projectilePrefab.transform.localScale.x;
        float spawnOffset = projectileScaleX / 2;
        float firstElementPos = -3 * projectileScaleX / 2 + spawnOffset;

        while (true)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + firstElementPos, 0, transform.position.z + 3);

            for (int i = -1; i < 2; i++)
            {
                var a = Instantiate(_projectilePrefab, spawnPos, Quaternion.identity);
                audioSource.PlayOneShot(weapon.GetAudio, 0.01f);
                Vector3 direction = Vector3.forward;
                direction.z += 4;
                direction.x = 1 * i;
                a.GetComponent<Projectile>().SetStats(direction, weapon.GetSpeed, weapon.GetDamage);

                spawnPos.x += projectileScaleX;
            }

            spawnPos.x = firstElementPos;
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
