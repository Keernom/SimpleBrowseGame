using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] Weapon weapon;

    public override void GetBonus(GameObject player)
    {
        player.GetComponent<PlayerShoot>().SetWeapon(weapon);
        GetManager().DestroyAllPickups();
    }
}
