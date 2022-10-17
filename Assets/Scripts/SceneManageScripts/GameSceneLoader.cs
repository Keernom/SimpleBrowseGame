using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameSceneLoader : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float _loadDelay = 1f;
    [SerializeField] AudioClip _clickSound;
    [SerializeField] AudioClip _enemyDeathSound;

    AudioSource _audioSource;

    bool _isPressed = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isPressed)
        {
            _audioSource = GetComponent<AudioSource>();

            EnemyHP[] _enemies = FindObjectsOfType<EnemyHP>();

            foreach (EnemyHP hp in _enemies)
            {
                hp.GetExplosion.GetComponent<AudioSource>().enabled = false;
                hp.EnemyDeath();
                hp.GetExplosion.GetComponent<AudioSource>().enabled = true;
            }

            _audioSource.PlayOneShot(_enemyDeathSound);

            FindObjectOfType<EnemySpawn>().StopSpawn();

            _audioSource.PlayOneShot(_clickSound);
            Invoke("LoadGameScene", _loadDelay);
            _isPressed = true;
        }
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
