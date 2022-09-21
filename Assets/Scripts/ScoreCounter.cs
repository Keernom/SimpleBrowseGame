using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] float _scoreMultiplier;

    float _scores;

    TextMeshProUGUI _text;

    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        _scores += Time.deltaTime * _scoreMultiplier;
        _text.text = Mathf.FloorToInt(_scores).ToString();
    }
}
