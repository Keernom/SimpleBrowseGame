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
    public static UnityAction onScoreEvent;
    float _scores;
    
    public float Scores { get { return _scores; } }

    float _startFontSize;
    float _finalFontSize;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _startFontSize = _text.fontSize;
        _fontSizeMultiplier = _fontSizeMultiplier / 100 + 1;
        _finalFontSize = _startFontSize * _fontSizeMultiplier;
    }

    public void ScoreUpdate(float scoreToPlus)
    {
        StopCoroutine(nameof(ChangeTextsize));

        _scores += scoreToPlus;
        _text.text = Mathf.FloorToInt(_scores).ToString();
        _text.fontSize = _finalFontSize;

        if (_scores >= _eventScores)
        {
            onScoreEvent?.Invoke();
            _eventScores = _scores < 500 ? _eventScores * 2.5f : _eventScores + 1000;
        }

        StartCoroutine(nameof(ChangeTextsize));
    }

    IEnumerator ChangeTextsize()
    {
        while (_text.fontSize > _startFontSize)
        {
            _text.fontSize -= Time.deltaTime / _timeToDefault * 25;
            yield return null;
        }
    }
}
