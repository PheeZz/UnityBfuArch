using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensitivity = 150f;
    public Transform orientation;

    float xRotation;
    float yRotation;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
     }

    void Update() { }

    void FixedUpdate()
    {

        // get mouse input
        float xSpeed = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity;
        float ySpeed = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity;

        // calculate rotation
        xRotation -= ySpeed;
        yRotation += xSpeed;

        // clamp rotation
        xRotation = Mathf.Clamp(xRotation, -60f, 60f);

        // rotate camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);
    }
}
