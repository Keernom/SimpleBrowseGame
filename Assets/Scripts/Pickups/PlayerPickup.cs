using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerPickup : Pickup
{
    [SerializeField] float _hpBooster;

    private void Start()
    {
        _hpBooster = Mathf.RoundToInt(Random.Range(1, 4)) * 10;
        text.text = $"{_hpBooster}%";
    }

    public override void GetBonus(GameObject player)
    {
        player.GetComponent<PlayerHP>().MaxHpUpdate(_hpBooster);

        GetManager().DestroyAllPickups();
    }
}
