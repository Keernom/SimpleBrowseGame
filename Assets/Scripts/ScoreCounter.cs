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

    Vector3 _startFontSize;
    Vector3 _finalFontSize;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _startFontSize = _text.gameObject.transform.localScale;
        _fontSizeMultiplier = _fontSizeMultiplier / 100 + 1;
        _finalFontSize = _startFontSize * _fontSizeMultiplier;
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
            float currentXScale = _text.gameObject.transform.localScale.x;
            float currentYScale = _text.gameObject.transform.localScale.y;
            _text.gameObject.transform.localScale = new Vector3(currentXScale - Time.deltaTime / _timeToDefault, currentYScale - Time.deltaTime / _timeToDefault, _startFontSize.z);
            //_text.gameObject.transform.localScale -= Time.deltaTime / _timeToDefault * 25;
            yield return null;
        }
    }
}
