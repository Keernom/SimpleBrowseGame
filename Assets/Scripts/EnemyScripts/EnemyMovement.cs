using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed = 1f;

    private void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * _speed);
        Camera camera = Camera.main;

        //if (transform.position.z < camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).z)
            //Destroy(gameObject);
    }
}
