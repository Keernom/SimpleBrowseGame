using UnityEngine;
using UnityEngine.Events;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosion;
    [SerializeField] Renderer _renderer;

    float _health = -1;
    public int Health { get { return Mathf.CeilToInt(_health); } }

    public UnityAction OnHit;

    ScoreCounter _scoreCounter;
    ColorController _colorController;
    Material _material;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        _colorController = FindObjectOfType<ColorController>();
        float hitPoints = Random.Range(_colorController.MaxHp / 2.5f, _colorController.MaxHp);
        _health = Mathf.CeilToInt(hitPoints);

        _material = _renderer.material;
        _material.SetColor("_Color", _colorController.GetColorByHealthPercent(_health / _colorController.MaxHp));
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            _scoreCounter.ScoreUpdate(damage + _health);
            EnemyDeath();
        }
        else
        {
            _scoreCounter.ScoreUpdate(damage);
            _material.SetColor("_Color", _colorController.GetColorByHealthPercent(_health / _colorController.MaxHp));
        }

        OnHit?.Invoke();
    }

    public void EnemyDeath()
    {
        var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
