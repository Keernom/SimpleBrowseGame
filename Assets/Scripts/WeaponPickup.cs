using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerShoot>().SetWeapon(weapon);

            WeaponPickup[] go = FindObjectsOfType<WeaponPickup>();
            int pickupsCount = go.Length;

            for(int i = 0; i < pickupsCount; i++)
            {
                Destroy(go[i].gameObject);
            }
        }
    }
}
