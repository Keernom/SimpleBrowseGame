using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class HpIndicator : MonoBehaviour
{
    TextMeshPro _text;
    EnemyHP enemyHP;

    private void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _text.text = enemyHP.Health.ToString();
    }

    private void OnEnable()
    {
        enemyHP = transform.parent.GetComponent<EnemyHP>();
        enemyHP.OnHit += LabelUpdate;
    }

    public void LabelUpdate()
    {
        _text.text = enemyHP.Health.ToString();
    }

    private void OnDisable()
    {
        enemyHP.OnHit -= LabelUpdate;
    }
}
