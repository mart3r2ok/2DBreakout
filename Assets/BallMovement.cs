using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 8f;        // постоянная скорость
    public float randomFactor = 0.05f; // немного рандома для разнообразия

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall(Vector2.up); // старт вверх
    }

    void LaunchBall(Vector2 direction)
    {
        rb.linearVelocity = Vector2.zero; // останавливаем мяч
        rb.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // удар об платформу
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleWidth = collision.collider.bounds.size.x;
            float hitPos = (transform.position.x - collision.transform.position.x) / (paddleWidth / 2);

            // направление зависит от точки удара (X = смещение, Y = вверх)
            Vector2 newDir = new Vector2(hitPos, 1f);

            // добавляем рандом, чтобы не зациклился
            newDir.x += Random.Range(-randomFactor, randomFactor);

            LaunchBall(newDir);
        }
        else
        {
            // удар об стены и блоки — обычное отражение
            Vector2 reflectDir = Vector2.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);

            // рандом для разнообразия
            reflectDir.x += Random.Range(-randomFactor, randomFactor);

            LaunchBall(reflectDir);
        }
    }
}