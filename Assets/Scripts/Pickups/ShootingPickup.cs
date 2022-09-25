using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPickup : Pickup
{
    Weapon _weapon;

    public override void GetBonus(GameObject player)
    {
        _weapon = player.GetComponent<PlayerShoot>().GetWeapon();
    }
}
