using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    [SerializeField] float _horizontalSpeed = 1f;

    Vector3 _movement;

    private void Update()
    {
        transform.Translate(_movement * Time.deltaTime * _speed);
    }

    public void SetDirection(int direction)
    {
        _movement = new Vector3(direction * _horizontalSpeed, 0, -1);
    }
}
