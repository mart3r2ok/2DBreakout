using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float timer = 0f;
    public float x = 0f;
    public float prevtransform, nowtransform;
    Rigidbody2D rb;
    public float speed = 5f;

    void Start()
    {
        nowtransform = gameObject.transform.position.y;
        prevtransform = nowtransform;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(2f, 5f).normalized * speed;
    }

    void Update()
    {
     rb.linearVelocity = rb.linearVelocity.normalized * speed;
        if (prevtransform == 4.926393f && nowtransform == 4.833545f || prevtransform == 4.833545f && nowtransform == 4.833545f)
        {
            x++;
        } else {
            x = 0;
        }
        prevtransform = nowtransform;
        nowtransform = (int)transform.position.y;
        timer += Time.deltaTime;
        if(x == 30 && timer <= 0.1f) {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 3);
            x = 0;
            timer = 0;
        }
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