using UnityEngine;

public class DefaultBlock : MonoBehaviour
{
    public GameManager gameManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // берём Rigidbody шара
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // считаем отражение по нормали
                Vector2 reflectDir = Vector2.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);

                // полностью останавливаем шар
                rb.linearVelocity = Vector2.zero;

                // придаём новое направление с постоянной скоростью
                float speed = 8f; // ту же скорость, что у тебя в Ball.cs
                rb.AddForce(reflectDir * speed, ForceMode2D.Impulse);
            }
            Destroy(gameObject);
            gameManager.countBlocks++;
            gameManager.check();
        }
    }
}
