using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
        FindObjectOfType<PlayerHP>().OnDeath += EnableButton;
    }

    private void EnableButton() => gameObject.SetActive(true);

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
