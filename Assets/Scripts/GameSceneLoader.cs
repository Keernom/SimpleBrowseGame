using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameSceneLoader : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] float _loadDelay = 1f;

    public void OnPointerClick(PointerEventData eventData)
    {
        Invoke("LoadGameScene", _loadDelay);
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
