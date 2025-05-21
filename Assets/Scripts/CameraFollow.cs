using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 defaultPosition = new Vector3(0, 15f, -10f);

    void LateUpdate()
    {
        if (target == null) return;

        // Бажана позиція камери
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y, target.position.z + defaultPosition.z);
    }
}
