﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSense = 100f;
    [SerializeField] public bool isPaused = false;

    public Transform playerBody;

    float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = true;
                print("Game Pasued");
                mouseSense = 0f;
            }
            if (!isPaused)
            {
                isPaused = false;
                print("Game Played");
                mouseSense = 100f;
            }
        }
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
