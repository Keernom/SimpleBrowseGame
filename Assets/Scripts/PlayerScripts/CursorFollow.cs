using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    [SerializeField] LayerMask _ground;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50, _ground))
        {
            Vector3 pos = hit.point;
            pos.y = 0;
            transform.SetPositionAndRotation(pos, Quaternion.identity);
        }
    }
}
