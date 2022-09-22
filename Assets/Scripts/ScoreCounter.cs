using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] float _scoreMultiplier;
    [SerializeField] float _fontSizeMultiplier;
    [SerializeField] float _timeToDefault;

    TextMeshProUGUI _text;

    float _scores;
    float _startFontSize;
    float _finalFontSize;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _startFontSize = _text.fontSize;
        _fontSizeMultiplier = _fontSizeMultiplier / 100 + 1;
        _finalFontSize = _startFontSize * _fontSizeMultiplier;
    }

    public void ScoreUpdate(int scoreToPlus)
    {
        StopCoroutine(nameof(ChangeTextsize));

        _scores += scoreToPlus;
        _text.text = Mathf.FloorToInt(_scores).ToString();
        _text.fontSize = _finalFontSize;

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
