using UnityEngine;
using UnityEngine.Events;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosion;
    [SerializeField] Renderer _renderer;

    float _health = -1;
    public int Health { get { return Mathf.RoundToInt(_health); } }

    public UnityAction OnHit;

    ScoreCounter _scoreCounter;
    ColorController _colorController;
    Material _material;

    private void Start()
    {
        _scoreCounter = FindObjectOfType<ScoreCounter>();
        _colorController = FindObjectOfType<ColorController>();
        float hitPoints = Random.Range(_colorController._maxHP/2.5f, _colorController._maxHP);
        _health = Mathf.RoundToInt(hitPoints);

        _material = _renderer.material;
        _material.SetColor("_Color", _colorController.GetColorByHealthPercent(_health / _colorController._maxHP));
    }

    public void ApplyDamage(float damage)
    {
        print(_health);
        _health -= damage;

        if (_health <= 0)
        {
            _scoreCounter.ScoreUpdate(damage + _health);
            EnemyDeath();
        }
        else
        {
            _scoreCounter.ScoreUpdate(damage);
            _material.SetColor("_Color", _colorController.GetColorByHealthPercent(_health / _colorController._maxHP));
        }

        OnHit?.Invoke();
    }

    public void EnemyDeath()
    {
        var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
