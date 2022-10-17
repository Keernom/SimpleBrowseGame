using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelEnable : MonoBehaviour
{
    PlayerHP _playerHP;

    private void Start()
    {
        _playerHP = FindObjectOfType<PlayerHP>();
        gameObject.SetActive(false);
        _playerHP.OnDeath += EnablePanel;
    }

    private void EnablePanel()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        _playerHP.OnDeath -= EnablePanel;
    }
}
