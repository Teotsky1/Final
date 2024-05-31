using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraBehaviour : MonoBehaviour
{
    public float sensitivity = 100f; 
    public Transform playerBody; 
    private float xRotation = 0f;
    private bool cursorlocked;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cursorlocked = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleCursorMode();
        }

        if(cursorlocked)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerBody.Rotate(Vector3.up * mouseX);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
       
    }






    void ToggleCursorMode()
    {
        if (Cursor.lockState == CursorLockMode.None)
        {
            LockCursor();
        }
        else
        {
            UnlockCursor();
        }
    }


    public void ConfineCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }


    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorlocked = true;
    }


    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cursorlocked = false;
    }

}
