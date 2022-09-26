using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPickup : Pickup
{
    [SerializeField] Stats _statToUpgrade;
    [SerializeField] float _upgradeValue;

    Weapon _weapon;

    public override void GetBonus(GameObject player)
    {
        _weapon = player.GetComponent<PlayerShoot>().GetWeapon();
        _weapon.UpdateStat(_statToUpgrade, _upgradeValue / 100);
        GetManager().AddInfoToUpgrade(_statToUpgrade, _upgradeValue / 100);
        GetManager().DestroyAllPickups();
    }
}
