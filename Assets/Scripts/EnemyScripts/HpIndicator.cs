using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HpIndicator : MonoBehaviour
{
    TextMeshPro _text;
    EnemyHP _enemyHP;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _text.text = _enemyHP.Health.ToString();
    }

    private void OnEnable()
    {
        _enemyHP = transform.parent.GetComponent<EnemyHP>();
        _enemyHP.OnHit += LabelUpdate;
    }

    public void LabelUpdate()
    {
        _text.text = _enemyHP.Health.ToString();
    }

    private void OnDisable()
    {
        _enemyHP.OnHit -= LabelUpdate;
    }
}
