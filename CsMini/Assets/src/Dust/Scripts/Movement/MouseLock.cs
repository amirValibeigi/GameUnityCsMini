using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public float touchSensitivity = 800f;

    public Transform playerBody;
    public Transform playerArms;

    float xRotation = 0f;

    MoveCameraHandler moveCameraHandler;

    // Start is called before the first frame update
    void Start()
    {
        moveCameraHandler = FindObjectOfType<MoveCameraHandler>();

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX;
        float mouseY;

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }
        else
        {
            mouseX = moveCameraHandler.position.x * touchSensitivity * Time.deltaTime;
            mouseY = moveCameraHandler.position.y * touchSensitivity * Time.deltaTime;
        }



        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 70f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerArms.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }


    bool isSafeTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            return touch.position.y >= 270f;
        }

        return false;
    }
}
