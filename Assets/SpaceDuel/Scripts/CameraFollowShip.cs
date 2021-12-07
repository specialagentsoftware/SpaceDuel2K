using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowShip : MonoBehaviour
{
    public Transform ship;
    public Vector3 CameraOffset;
    public float CameraScrollSensitivity = 1f;
    public float minCameraOffset = 10f;
    public float maxCameraOffset = 25f;

    void Update()
    {
        if (ship != null)
        {
            CameraOffset.y += Input.mouseScrollDelta.y * CameraScrollSensitivity * -1f;

            if (CameraOffset.y < minCameraOffset)
            {
                CameraOffset.y = minCameraOffset;
            }

            if (CameraOffset.y > maxCameraOffset)
            {
                CameraOffset.y = maxCameraOffset;
            }

            transform.position = ship.position + CameraOffset;
        }


    }
}
