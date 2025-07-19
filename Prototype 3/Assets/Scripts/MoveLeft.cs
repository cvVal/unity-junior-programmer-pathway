using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30f;
    private float leftBound = -15f;
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = FindFirstObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGameOver == false)
        {
            MoveBackground();
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

    private void MoveBackground()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
