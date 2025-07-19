using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 0.3f;
    private float rotationSpeed = 100.0f;
    private float verticalInput;

    // Camera switching variables
    public Camera camera1;
    public Camera camera2;
    private bool isCamera1Active = true;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure only camera1 is active at start
        if (camera1 != null && camera2 != null)
        {
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(rotationSpeed * Time.deltaTime * verticalInput * Vector3.right);
    }

    void Update()
    {
        // Check for camera switch input
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        if (camera1 != null && camera2 != null)
        {
            if (isCamera1Active)
            {
                // Switch to camera2
                camera1.enabled = false;
                camera2.enabled = true;
                isCamera1Active = false;
            }
            else
            {
                // Switch to camera1
                camera2.enabled = false;
                camera1.enabled = true;
                isCamera1Active = true;
            }
        }
    }
}
