using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] Weapon _defaultWeapon;
    [SerializeField] Transform _spawnPoint;

    void Start()
    {
        _defaultWeapon.Spawn(_spawnPoint);
        _defaultWeapon.Shoot();
    }

    //IEnumerator Shooting()
    //{
    //    while(true)
    //    {
    //        //var go = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            
    //        yield return new WaitForSeconds(.5f);
    //    }
    //}

    public Weapon GetWeapon()
    {
        return _defaultWeapon;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
