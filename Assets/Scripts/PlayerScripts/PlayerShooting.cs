using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject _projectile;

    void Start()
    {
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while(true)
        {
            var go = Instantiate(_projectile, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(.5f);
        }
    }
}
