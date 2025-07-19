using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private new Rigidbody rigidbody;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Move towards the player
        // Normalize is used to ensure that the enemy moves at a consistent speed regardless of distance
        // This means that no matter how far the player is, the enemy will always move at the same speed
        rigidbody.AddForce(speed * lookDirection);

        if (transform.position.y < -10)
            Destroy(gameObject); // Destroy enemy if it falls below a certain height
    }
}
