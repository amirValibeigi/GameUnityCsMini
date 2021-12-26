using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MouseLock : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public float touchSensitivity = 800f;

    public Transform playerBody;
    public Transform playerArms;

    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;

        if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }
        else
        {
            if (Touchscreen.current.touches.Count == 0)
                return;

            if (EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[0].touchId.ReadValue()))
            {
                if (Touchscreen.current.touches.Count > 1 && Touchscreen.current.touches[1].isInProgress)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[1].touchId.ReadValue()))
                        return;

                    Vector2 touchDeltaPosition = Touchscreen.current.touches[1].delta.ReadValue();
                    mouseX = touchDeltaPosition.x;
                    mouseY = touchDeltaPosition.y;
                }
            }
            else
            {
                if (Touchscreen.current.touches.Count > 0 && Touchscreen.current.touches[0].isInProgress)
                {
                    if (EventSystem.current.IsPointerOverGameObject(Touchscreen.current.touches[0].touchId.ReadValue()))
                        return;

                    Vector2 touchDeltaPosition = Touchscreen.current.touches[0].delta.ReadValue();
                    mouseX = touchDeltaPosition.x;
                    mouseY = touchDeltaPosition.y;
                }

            }
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
