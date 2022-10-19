using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosionEffect; 
    [SerializeField] SpriteRenderer _hitBar;
    [SerializeField] float _maxHealth = 1;

    public UnityAction OnDeath;
    ColorController _colorController;
    LeaderBoard _leaderBoard;

    Vector3 _startScale;
    float _currentHealth;

    bool _isAlive = true;
    public bool IsAlive { get { return _isAlive; } }

    private void Start()
    {
        _leaderBoard = FindObjectOfType<LeaderBoard>();
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
            OnDeath?.Invoke();
            Death();
            ProjectileDestuction();
            _isAlive = false;
            _leaderBoard.GenLB();
        }
    }

    private void ProjectileDestuction()
    {
        Projectile[] projectiles = FindObjectsOfType<Projectile>();

        foreach(var item in projectiles)
        {
            item.ProjectileExplosion();
        }
    }

    

    private void Death()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        GetComponent<PlayerShoot>().GetWeapon().DestroyWeapon();
        Destroy(gameObject);
    }

    void SetHealthBarColor()
    {
        Color newColor = _colorController.GetColorByHealthPercent(1 - _currentHealth / _maxHealth);
        newColor.a = 255;

        _hitBar.color = newColor;

        Vector3 newScale = new Vector3(1 - _currentHealth / _maxHealth * _startScale.x, _startScale.y, _startScale.z);
        _hitBar.gameObject.transform.localScale = newScale;
    }

    public void MaxHpUpdate(float percentBonus)
    {
        float hpPart = _currentHealth / _maxHealth;

        float multiplier = percentBonus / 100;
        _maxHealth += _maxHealth * multiplier;

        _currentHealth = Mathf.RoundToInt(_maxHealth * hpPart);
    }
}
