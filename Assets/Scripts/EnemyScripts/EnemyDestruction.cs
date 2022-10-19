﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestruction : MonoBehaviour
{
    private void Start()
    {
        Camera camera = Camera.main;

        Vector3 worldSpawnPoint = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.transform.position.y));
    }

    private void OnBecameInvisible()
    {


        Destroy(transform.parent.gameObject);
    }
}
