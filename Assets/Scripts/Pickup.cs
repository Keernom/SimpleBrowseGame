using System.Collections;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    float _speed = .4f;
    UpgradeManager _upgradeManger;

    public abstract void GetBonus(GameObject player);

    private void Start()
    {
        _upgradeManger = FindObjectOfType<UpgradeManager>();
        StartCoroutine(MoveToCenter());
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
