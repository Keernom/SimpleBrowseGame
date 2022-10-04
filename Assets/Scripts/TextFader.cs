using System.Collections;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(CanvasRenderer))]
public class TextFader : MonoBehaviour
{
    [Header("Fade Settings")]
    [SerializeField] float _fadeTime = 2;

    TMP_Text _text;
    CanvasRenderer _canvas;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _canvas = GetComponent<CanvasRenderer>();
        StartCoroutine(nameof(Fade), _fadeTime);
    }

    public IEnumerator Fade(float time)
    {
        while (true)
        {
            while (_canvas.GetAlpha() > 0.5)
            {
                _canvas.SetAlpha(_canvas.GetAlpha() - Time.deltaTime / time);
                _text.fontSize -= Time.deltaTime / time * 10; 
                yield return null;
            }

            while (_canvas.GetAlpha() < 1)
            {
                _canvas.SetAlpha(_canvas.GetAlpha() + Time.deltaTime / time);
                _text.fontSize += Time.deltaTime / time * 10;
                yield return null;
            }
        }
    }
}
