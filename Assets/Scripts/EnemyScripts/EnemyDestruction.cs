using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    float _bottomZ;

    private void Start()
    {
        Camera camera = Camera.main;

        Vector3 worldBottomCoords = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.transform.position.y));
        _bottomZ = worldBottomCoords.z;
    }

    private void FixedUpdate()
    {
        if (transform.parent.gameObject.transform.position.z < _bottomZ)
            Destroy(transform.parent.gameObject, 1f);
    }
}
