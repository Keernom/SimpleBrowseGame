using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed = 1f;

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
