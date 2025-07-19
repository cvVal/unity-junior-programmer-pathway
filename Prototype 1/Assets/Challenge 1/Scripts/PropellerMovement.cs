using UnityEngine;

public class PropellerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate()
    {
        // Rotate the propeller around its local Z axis at a constant speed
        transform.Rotate(500 * Time.deltaTime * Vector3.forward);
    }
}
