using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    [SerializeField] float _levelLoadDelay;
    [SerializeField] AudioClip _buttonPressedSound;

    private void Start()
    {
        gameObject.SetActive(false);
        FindObjectOfType<PlayerHP>().OnDeath += EnableButton;
    }

    private void EnableButton() => gameObject.SetActive(true);

    public void Restart()
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPressedSound);
        Invoke("SceneLoad", _levelLoadDelay);
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
