using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] public float _maxHP = 0;
    [SerializeField] float _hpMultiplier;
    [SerializeField] List<Color> _colorList;

    public float MaxHp { get { return Mathf.FloorToInt(_maxHP); } }

    Dictionary<float, Color> _colorDict = new Dictionary<float, Color>();
    List<float> _keyList = new List<float>();

    private void Awake()
    {
        SetDictionary();
        ScoreCounter.onScoreEvent += MaxHpUpdate;
    }

    void SetDictionary()
    {
        _colorDict.Clear();

        _colorDict.Add(1, _colorList[0]);
        _keyList.Add(1);

        for (int i = 1; i < _colorList.Count; i++)
        {
            float hpInterval = _maxHP / _colorList.Count * (_colorList.Count - i);
            _colorDict.Add(hpInterval / _maxHP, _colorList[i]);
            _keyList.Add(hpInterval / _maxHP);
        }
    }

    public Color GetColorByHealthPercent(float health)
    {
        for (int i = 0; i < _keyList.Count;i++)
        {
            if (i ==  _keyList.Count-1)
                return _colorDict[_keyList[i]];

            if (health <= _keyList[i] && health > _keyList[i + 1])
                return _colorDict[_keyList[i]];
        }

        return Color.black;
    }

    void MaxHpUpdate()
    {
        _maxHP += _maxHP * _hpMultiplier;
    }
}
