using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] float _fontSizeMultiplier;
    [SerializeField] float _timeToDefault;
    [SerializeField] float _eventScores;

    TextMeshProUGUI _text;
    PlayerHP _playerHp;
    public static UnityAction onScoreEvent;
    float _scores;
    
    public float Scores { get { return _scores; } }

    Vector3 _startFontSize;
    Vector3 _finalFontSize;

    void Start()
    {
        _playerHp = FindObjectOfType<PlayerHP>();
        _text = GetComponent<TextMeshProUGUI>();
        _startFontSize = _text.gameObject.transform.localScale;
        _fontSizeMultiplier = _fontSizeMultiplier / 100 + 1;
        _finalFontSize = _startFontSize * _fontSizeMultiplier;

        _playerHp.OnDeath += MoveText;
    }

    public void MoveText()
    {
        GetComponent<Animator>().SetTrigger("Move");
    }

    public void ScoreUpdate(float scoreToPlus)
    {
        StopCoroutine(nameof(ChangeTextsize));

        _scores += scoreToPlus;
        _text.text = Mathf.FloorToInt(_scores).ToString();
        _text.gameObject.transform.localScale = _finalFontSize;

        if (_scores >= _eventScores)
        {
            onScoreEvent?.Invoke();
            _eventScores = _scores < 500 ? _eventScores * 2.5f : _eventScores + 1000;
        }

        StartCoroutine(nameof(ChangeTextsize));
    }

    IEnumerator ChangeTextsize()
    {
        while (_text.gameObject.transform.localScale.x > _startFontSize.x)
        {
            Vector3 localScale = _text.gameObject.transform.localScale;
            float currentXScale = localScale.x;
            float currentYScale = localScale.y;
            _text.gameObject.transform.localScale = new Vector3(currentXScale - Time.deltaTime / _timeToDefault, currentYScale - Time.deltaTime / _timeToDefault, _startFontSize.z);
            yield return null;
        }
    }

    private void OnDisable()
    {
        _playerHp.OnDeath -= MoveText;
    }
}
