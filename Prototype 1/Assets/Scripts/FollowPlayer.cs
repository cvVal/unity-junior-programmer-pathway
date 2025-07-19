using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the PlayerController script
    [SerializeField] Vector3 offset; // Offset position for the camera
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    // LateUpdate is called once per frame after all Update functions have been called
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
