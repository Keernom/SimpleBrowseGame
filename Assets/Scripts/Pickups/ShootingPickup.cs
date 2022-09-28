using TMPro;
using UnityEngine;

public class ShootingPickup : Pickup
{
    [SerializeField] Stats _statToUpgrade;
    
    Weapon _weapon;
    float _upgradeValue;

    private void Start()
    {
        _upgradeValue = Mathf.RoundToInt(Random.Range(1, 4)) * 10;
        text.text = $"{_upgradeValue}%";
    }

    public override void GetBonus(GameObject player)
    {
        _weapon = player.GetComponent<PlayerShoot>().GetWeapon();
        _weapon.UpdateStat(_statToUpgrade, _upgradeValue / 100);
        GetManager().AddInfoToUpgrade(_statToUpgrade, _upgradeValue / 100);
        GetManager().DestroyAllPickups();
    }
}
