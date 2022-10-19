using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBottom : MonoBehaviour
{
    private void Start()
    {
        Camera camera = Camera.main;

        Vector3 worldSpawnPoint = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.transform.position.y));
    }
}
