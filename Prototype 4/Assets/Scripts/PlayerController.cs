using System.Collections;
using UnityEngine;

/// <summary>
/// Controls player movement, powerup mechanics, and collision interactions
/// This script manages the player's physics-based movement and powerup system
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Private fields - internal components and settings
    private new Rigidbody rigidbody;        // Reference to the player's Rigidbody component for physics
    private GameObject focalPoint;          // Reference to the camera's focal point for directional movement
    private readonly float powerupStrength = 15f;  // Force multiplier when player has powerup active

    // Public fields - exposed in Unity Inspector for easy adjustment
    public float speed = 5f;               // Player movement speed multiplier
    public bool hasPowerup = false;        // Tracks whether player currently has powerup active
    public GameObject powerupIndicator;    // Visual indicator that shows when powerup is active

    /// <summary>
    /// Initialization method called once when the GameObject is first created
    /// Sets up references to required components and GameObjects
    /// </summary>
    void Start()
    {
        // Get the Rigidbody component attached to this GameObject for physics interactions
        rigidbody = GetComponent<Rigidbody>();
        
        // Find the Focal Point GameObject in the scene - this determines movement direction
        // The focal point is typically a child of the camera that rotates with it
        focalPoint = GameObject.Find("Focal Point");
    }

    /// <summary>
    /// Called every frame to handle player input and update game state
    /// Manages player movement and powerup indicator positioning
    /// </summary>
    void Update()
    {
        // Get vertical input from keyboard (W/S keys or Up/Down arrows)
        // Returns a value between -1 and 1 based on input
        float verticalInput = Input.GetAxis("Vertical");
        
        // Apply physics force to move the player
        // Force calculation: speed * input * forward direction of focal point
        // This creates movement that follows the camera's orientation
        rigidbody.AddForce(speed * verticalInput * focalPoint.transform.forward);
        
        // Update powerup indicator position to follow the player
        // Places the indicator slightly below the player (0.5 units down on Y-axis)
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    /// <summary>
    /// Handles trigger collision events (when player enters a trigger collider)
    /// Specifically handles powerup collection
    /// </summary>
    /// <param name="other">The collider that triggered this event</param>
    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Powerup" tag
        if (other.CompareTag("Powerup"))
        {
            // Activate the powerup state
            hasPowerup = true;
            
            // Make the powerup indicator visible
            powerupIndicator.SetActive(true);
            
            // Remove the powerup object from the scene
            Destroy(other.gameObject);
            
            // Log powerup activation for debugging
            Debug.Log("Powerup activated!");
            
            // Start the countdown timer to deactivate powerup after 7 seconds
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    /// <summary>
    /// Handles physical collision events (when player collides with solid objects)
    /// Implements the powerup knock-back effect against enemies
    /// </summary>
    /// <param name="collision">Information about the collision that occurred</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided object is an enemy AND player has powerup active
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            // Log collision details for debugging
            Debug.Log("Player collided with " + collision.gameObject.name + " with powerup set to " + hasPowerup);
            
            // Get the enemy's Rigidbody component to apply physics forces
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Calculate direction vector from player to enemy
            // This determines which direction to push the enemy
            // If the substraction is reversed, it will push the player towards the enemy instead
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            
            // Apply impulse force to knock the enemy away from the player
            // Uses powerupStrength multiplier and Impulse mode for immediate effect
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Coroutine that manages the powerup duration timer
    /// Automatically deactivates the powerup after a set time period
    /// </summary>
    /// <returns>IEnumerator for coroutine execution</returns>
    IEnumerator PowerupCountdownRoutine()
    {
        // Wait for 7 seconds before deactivating powerup
        yield return new WaitForSeconds(7);
        
        // Deactivate powerup state
        hasPowerup = false;
        
        // Hide the powerup indicator
        powerupIndicator.SetActive(false);
        
        // Log powerup deactivation for debugging
        Debug.Log("Powerup has ended");
    }
}
