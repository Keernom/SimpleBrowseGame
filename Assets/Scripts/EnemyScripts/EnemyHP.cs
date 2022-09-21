using UnityEngine;
using UnityEngine.Events;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] ParticleSystem _explosion;

    int _health = -1;
    public int Health { get { return _health; } }

    public UnityAction OnHit;

    ColorController _colorController;
    Material _material;

    private void Start()
    {
        _colorController = FindObjectOfType<ColorController>();
        float hitPoints = Random.Range(_colorController._maxHP/2.5f, _colorController._maxHP);
        _health = Mathf.RoundToInt(hitPoints);

        _material = transform.GetChild(0).GetComponent<Renderer>().material;
        _material.SetColor("_Color", _colorController.GetColor(_health));
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        _material.SetColor("_Color", _colorController.GetColor(_health));

        if (_health <= 0)
        {
            var explosion = Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        OnHit?.Invoke();
    }
}
