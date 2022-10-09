using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] Weapon _weapon;

    public Weapon GetPickupWeapon { get { return _weapon; } }

    public override void GetBonus(GameObject player)
    {
        player.GetComponent<PlayerShoot>().SetWeapon(_weapon);
        GetManager().DestroyAllPickups();
    }
}
