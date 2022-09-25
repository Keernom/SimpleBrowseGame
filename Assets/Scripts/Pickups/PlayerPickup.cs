using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : Pickup
{
    [SerializeField] float _hpBooster;

    public override void GetBonus(GameObject player)
    {
        player.GetComponent<PlayerHP>().MaxHpUpdate(_hpBooster);

        GetManager().DestroyAllPickups();
    }
}
