using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public UpgradeManager _upgradeManger;

    public abstract void GetBonus(GameObject player);

    private void Start()
    {
        _upgradeManger = FindObjectOfType<UpgradeManager>();
        Destroy(gameObject, _upgradeManger.PickUpLifeTime);
    }
}
