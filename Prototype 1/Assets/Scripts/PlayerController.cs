using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f; // Speed of the player movement
    private float turnSpeed = 45.0f; // Speed of the player turning
    private float horizontalInput; // Horizontal input for turning
    private float verticalInput; // Vertical input for moving forward and backward
    
    // Camera switching variables
    public Camera camera1;
    public Camera camera2;
    private bool isCamera1Active = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make sure only camera1 is active at start
        if (camera1 != null && camera2 != null)
        {
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }

    void Update()
    {
        // Check for camera switch input
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(verticalInput * Time.deltaTime * speed * Vector3.forward);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(horizontalInput * Time.deltaTime * turnSpeed * Vector3.up);
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
