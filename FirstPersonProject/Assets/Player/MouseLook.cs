using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
#pragma warning disable 649

    [SerializeField] float sensitivityX = 0.25f;
    [SerializeField] float sensitivityY = 0.25f;
    float mouseX, mouseY;

    [SerializeField] Transform playerCamera;
    float xRotation = 0f;

    public float lookSpeed = 1f;
    public float lookXLimit = 45f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

        xRotation += -mouseY * lookSpeed;
        xRotation = Mathf.Clamp(xRotation, -lookXLimit, lookXLimit);
        Vector3 targetRotation = transform.eulerAngles;
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseX * lookSpeed, 0);
        targetRotation.x = xRotation;
        playerCamera.eulerAngles = targetRotation;
    }

    public void ReceiveInput (Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }
}
