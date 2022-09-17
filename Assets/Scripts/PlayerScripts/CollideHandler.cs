using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideHandler : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            
        }
    }
}
