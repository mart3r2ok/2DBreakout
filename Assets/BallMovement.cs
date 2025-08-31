using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(2f, 5f).normalized * speed;
    }

    void Update()
    {
        // фиксируем модуль скорости, чтобы шар не ускорялся/не замедлялся
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // удар об платформу ? меняем угол в зависимости от точки касания
            float x = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, 1).normalized;
            rb.linearVelocity = dir * speed;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // удар об боковые стены ? отражение по X
            rb.linearVelocity = new Vector2(-rb.linearVelocity.x, rb.linearVelocity.y);
        }
        else if (collision.gameObject.CompareTag("Ceiling"))
        {
            // удар об потолок ? отражение по Y
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleWidth)
    {
        // возвращает -1 (лево) ... 0 (центр) ... 1 (право)
        return (ballPos.x - paddlePos.x) / paddleWidth;
    }
}