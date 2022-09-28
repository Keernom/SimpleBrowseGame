using System.Collections;
using TMPro;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] protected TextMeshPro text;

    float _speed;
    UpgradeManager _upgradeManger;

    public abstract void GetBonus(GameObject player);

    private void OnEnable()
    {
        int lastChildindex = transform.childCount - 1;
        text = transform.GetChild(lastChildindex).GetComponent<TextMeshPro>();
        _upgradeManger = FindObjectOfType<UpgradeManager>();
        _speed = _upgradeManger.PickupSpeed;
        StartCoroutine(MoveToCenter());
    }

    private void Start()
    {
        
    }

    public UpgradeManager GetManager()
    {
        return _upgradeManger;
    }

    IEnumerator MoveToCenter()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = new Vector3(startPosition.x, 0, 0);
        float travelPercent = 0f;

        while(travelPercent < 1)
        {
            travelPercent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
            yield return new WaitForEndOfFrame();
        }
    }
}
