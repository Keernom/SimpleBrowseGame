using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] SpriteRenderer _hitBar;
    [SerializeField] int _maxHealth = 1;

    
    ColorController _colorController;

    float _currentHealth;

    Vector3 _startScale;

    private void Start()
    {
        _colorController = FindObjectOfType<ColorController>();
        _currentHealth = _maxHealth;

        Transform hitBarTransform = _hitBar.gameObject.transform;
        _startScale = new Vector3(hitBarTransform.localScale.x, hitBarTransform.localScale.y, hitBarTransform.localScale.z);

        SetHealthBarColor();
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        SetHealthBarColor();

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void SetHealthBarColor()
    {
        Color newColor = _colorController.GetColorByHealthPercent(1 - _currentHealth / _maxHealth);
        newColor.a = 255;

        _hitBar.color = newColor;

        Vector3 newScale = new Vector3(1 - _currentHealth / _maxHealth * _startScale.x, _startScale.y, _startScale.z);
        _hitBar.gameObject.transform.localScale = newScale;
    }
}
