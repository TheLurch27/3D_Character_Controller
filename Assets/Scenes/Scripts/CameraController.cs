using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float distance = 5;

    [SerializeField] private float minVerticalAngle = -45;
    [SerializeField] private float maxVerticalAngle = 45;

    [SerializeField] private Vector2 framingOffset;

    [SerializeField] private bool invertY;
    [SerializeField] private bool invertX;

    float rotationX;
    float rotationY;

    float invertXValue;
    float invertYValue;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        invertXValue = (invertX) ? -1 : 1;
        invertYValue = (invertY) ? -1 : 1;

        rotationX += Input.GetAxis("Mouse Y") * invertYValue * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVerticalAngle, maxVerticalAngle);

        rotationY += Input.GetAxis("Mouse X") * invertXValue * rotationSpeed;

        var targetRotation = Quaternion.Euler(rotationX, rotationY, 0);

        var focusPoint = target.position + new Vector3(framingOffset.x, framingOffset.y);

        transform.position = focusPoint - targetRotation * new Vector3(0, 0, distance);
        transform.rotation = targetRotation;
    }
}
