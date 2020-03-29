using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float angleX;
    float angleY;
    public float sensY;
    public float sensX;
    public Transform body;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        angleX += mouseX * sensX;
        angleY += mouseY * sensY;

        angleY = Mathf.Clamp(angleY, -85f, 85f);

        transform.localRotation = Quaternion.Euler(-angleY, 0, 0);
        body.transform.localRotation = Quaternion.Euler(0, angleX, 0);
    }
}
