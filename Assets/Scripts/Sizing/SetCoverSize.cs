using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCoverSize : MonoBehaviour
{
    private void Start()
    {
        Camera camera = Camera.main;

        Vector3 worldBottomCoords = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.transform.position.y));

        float xSize = Mathf.Abs(worldBottomCoords.x);
        float zSize = Mathf.Abs(worldBottomCoords.z);
        GetComponent<BoxCollider>().size = new Vector3(xSize*2, 1, zSize*2);
    }
}
