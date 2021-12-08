using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    public Transform cameraTransform;
    public Transform followTransform;

    float movementSpeed;
    float movementTime = 10;
    float normalSpeed = 50;
    float fastSpeed = 100;
    float rotationSpeed = 100;
    Vector3 zoomSpeed = new Vector3(0, -200, 200);

    Vector3 newPosition;
    Quaternion newRotation;
    Vector3 newZoom;

    Vector3 rotationStartPosition;
    Vector3 rotationCurrentPosition;

    private void Start()
    {
        if (instance && instance != this)
            Destroy(this.gameObject);
        else
            instance = this;
        newPosition = transform.position;
        newRotation = transform.rotation;
        newZoom = cameraTransform.localPosition;
    }

    private void LateUpdate()
    {
        if (followTransform)
            newPosition = followTransform.position;

        HandleCameraInput();
    }

    void HandleCameraInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            movementSpeed = fastSpeed;
        else
            movementSpeed = normalSpeed;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed * Time.deltaTime);
            followTransform = null;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed * Time.deltaTime);
            followTransform = null;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed * Time.deltaTime);
            followTransform = null;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed * Time.deltaTime);
            followTransform = null;
        }

        if (Input.GetKey(KeyCode.Q))
            newRotation *= Quaternion.Euler(Vector3.up * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.E))
            newRotation *= Quaternion.Euler(Vector3.up * -rotationSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(2))
            rotationStartPosition = Input.mousePosition;
        if (Input.GetMouseButton(2))
        {
            rotationCurrentPosition = Input.mousePosition;
            Vector3 difference = rotationStartPosition - rotationCurrentPosition;
            rotationStartPosition = rotationCurrentPosition;
            newRotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5));
        }

        if (Input.GetKey(KeyCode.R))
            newZoom += zoomSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.F))
            newZoom -= zoomSpeed * Time.deltaTime;
        if (Input.mouseScrollDelta.y != 0)
            newZoom += Input.mouseScrollDelta.y * zoomSpeed * Time.deltaTime * 5;
        newZoom.y = Mathf.Clamp(newZoom.y, 50, 500);
        newZoom.z = Mathf.Clamp(newZoom.z, -500, -50);

        transform.position = Vector3.Lerp(transform.position, newPosition, movementTime * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, movementTime * Time.deltaTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, movementTime * Time.deltaTime);
    }

    private void OnDestroy()
    {
        if (this == instance)
            instance = null;
    }
}
