using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAim : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    float xRotation = 0f;

    //Walking
    public float speed = .1f;
    private Animator mAnimator;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 60f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f );
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
