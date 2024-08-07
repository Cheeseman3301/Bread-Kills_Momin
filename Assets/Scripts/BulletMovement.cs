using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 4f; // Public variable for setting bullet speed in Inspector
    private Rigidbody2D rb; // Private Rigidbody2D reference
    [SerializeField] private int maxBounces = 7; // Maximum number of bounces (already serialized)
    [SerializeField] private Vector2 direction; // Bullet's direction (already serialized)
    private Vector3 lastVelocity; // Stores the previous velocity
    private int bounceCount = 0; // Tracks the number of bounces
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
       
     
        var newSpeed = lastVelocity.magnitude;
        var newDirection = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = newDirection * Mathf.Max(newSpeed, 0f);

        if (collision.gameObject.CompareTag("Enemy"))
        {
            kills++;
            Cyborg cyborg = collision.gameObject.GetComponent<Cyborg>();
            cyborg.OnHit();
        }

        if (bounceCount >= maxBounces)
        {
            Destroy(gameObject); 
        }
    }
}