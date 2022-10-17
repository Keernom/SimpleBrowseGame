using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneRestart : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float _levelLoadDelay;
    [SerializeField] AudioClip _buttonPressedSound;

    PlayerHP _playerHP;

    private void Start()
    {
        _playerHP = FindObjectOfType<PlayerHP>();
        gameObject.SetActive(false);
        _playerHP.OnDeath += EnableTrigger;
    }

    private void EnableTrigger()
    {
        gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPressedSound);
        Invoke("SceneLoad", _levelLoadDelay);
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        _playerHP.OnDeath -= EnableTrigger;
    }
}
