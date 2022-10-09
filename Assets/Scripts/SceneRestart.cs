using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneRestart : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float _levelLoadDelay;
    [SerializeField] AudioClip _buttonPressedSound;

    private void Start()
    {
        gameObject.SetActive(false);
        FindObjectOfType<PlayerHP>().OnDeath += EnableTrigger;
    }

    private void EnableTrigger()
    {
        gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GetComponent<AudioSource>().PlayOneShot(_buttonPressedSound);
        print("asd");
        Invoke("SceneLoad", _levelLoadDelay);
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
