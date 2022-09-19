using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    [SerializeField] public int _maxHP = 0;

    [SerializeField] List<Color> _colorList;

    Dictionary<int, Color> _colorDict = new Dictionary<int, Color>();
    [SerializeField]List<int> _keyList = new List<int>();

    private void Start()
    {
        SetDictionary();
    }

    void SetDictionary()
    {
        _colorDict.Clear();

        _colorDict.Add(_maxHP, _colorList[0]);
        _keyList.Add(_maxHP);

        for (int i = 1; i < _colorList.Count; i++)
        {
            _colorDict.Add(_maxHP / _colorList.Count * (_colorList.Count - i), _colorList[i]);
            _keyList.Add(_maxHP / _colorList.Count * (_colorList.Count - i));
        }
    }

    public Color GetColor(int health)
    {
        for (int i = 0; i < _keyList.Count;i++)
        {
            if (i == _keyList.Count-1)
                return _colorDict[_keyList[i]];

            if (health <= _keyList[i] && health > _keyList[i + 1])
                return _colorDict[_keyList[i]];
        }

        return Color.black;
    }
}
