using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f; // Public variable for setting bullet speed in Inspector
    private Rigidbody2D rb; // Private Rigidbody2D reference
    [SerializeField] private int maxBounces = 20; // Maximum number of bounces (already serialized)
    private int bounceCount = 0; // Tracks the number of bounces
    [SerializeField] private Vector2 direction; // Bullet's direction (already serialized)
    private Vector3 lastVelocity; // Stores the previous velocity
     public int kills = 0; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    public void Shoot(Vector2 direction)
    {
        this.direction = direction;
        rb.velocity = direction * speed; // Set initial velocity
    }

    void Update()
    {
        lastVelocity = rb.velocity; // Update lastVelocity
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bounceCount++;

        string objectName = collision.gameObject.name;
        Debug.Log("Collided with: " + objectName);
        Debug.Log("Bounces: " + bounceCount);

        // Calculate new direction and speed based on collision
        var newSpeed = lastVelocity.magnitude;
        var newDirection = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = newDirection * Mathf.Max(newSpeed, 0f);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            kills++;
            Cyborg cyborg = collision.gameObject.GetComponent<Cyborg>();

            Destroy(collision.gameObject); // Destroy the enemy on collision
        }

        if (bounceCount >= maxBounces)
        {
            Debug.Log("Maximum bounces reached, destroying bullet");
            Destroy(gameObject); // Destroy the bullet after exceeding bounces
        }
    }
}
