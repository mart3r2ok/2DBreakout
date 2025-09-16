using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 8f;
    public float randomFactor = 0.05f;
    public float minXAngle = 0.3f;
    public float minYAngle = 0.3f; 
    public float maxYAngle = 0.95f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.LogError("❌ Rigidbody2D не найден на объекте с BallMovement!");
            return;
        }

        rb.gravityScale = 0f;
        rb.drag = 0f;
        rb.angularDrag = 0f;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.velocity = Vector2.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb == null) return;
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleWidth = collision.collider.bounds.size.x;
            float hitPos = (transform.position.x - collision.transform.position.x) / (paddleWidth / 2);

            Vector2 newDir = new Vector2(hitPos, 1f);
            newDir.x += Random.Range(-randomFactor, randomFactor);

            rb.velocity = NormalizeDirection(newDir) * speed;
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            if (collision.contacts != null && collision.contacts.Length > 0)
            {
                Vector2 reflectDir = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
                reflectDir.x += Random.Range(-randomFactor, randomFactor);

                rb.velocity = NormalizeDirection(reflectDir) * speed;
            }
            else
            {
                Debug.LogWarning("⚠️ Нет контактных точек при столкновении с Block: " + collision.gameObject.name);
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y).normalized * speed;
            }
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        if (rb.velocity.sqrMagnitude < 0.01f)
        {
            Vector2 fallbackDir = new Vector2(Random.Range(-0.5f, 0.5f), 1f);
            rb.velocity = NormalizeDirection(fallbackDir) * speed;
        }
        else
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }

    Vector2 NormalizeDirection(Vector2 dir)
    {
        dir = dir.normalized;
        if (Mathf.Abs(dir.x) < minXAngle)
            dir.x = minXAngle * Mathf.Sign(dir.x == 0 ? 1 : dir.x);
        float signY = Mathf.Sign(dir.y);
        dir.y = Mathf.Clamp(Mathf.Abs(dir.y), minYAngle, maxYAngle) * signY;

        return dir.normalized;
    }
}