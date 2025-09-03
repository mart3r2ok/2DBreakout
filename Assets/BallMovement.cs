using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 8f;        // ���������� ��������
    public float randomFactor = 0.05f; // ������� ������� ��� ������������

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall(Vector2.up); // ����� �����
    }

    void LaunchBall(Vector2 direction)
    {
        rb.linearVelocity = Vector2.zero; // ������������� ���
        rb.AddForce(direction.normalized * speed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� �� ���������
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleWidth = collision.collider.bounds.size.x;
            float hitPos = (transform.position.x - collision.transform.position.x) / (paddleWidth / 2);

            // ����������� ������� �� ����� ����� (X = ��������, Y = �����)
            Vector2 newDir = new Vector2(hitPos, 1f);

            // ��������� ������, ����� �� ����������
            newDir.x += Random.Range(-randomFactor, randomFactor);

            LaunchBall(newDir);
        }
        else
        {
            // ���� �� ����� � ����� � ������� ���������
            Vector2 reflectDir = Vector2.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);

            // ������ ��� ������������
            reflectDir.x += Random.Range(-randomFactor, randomFactor);

            LaunchBall(reflectDir);
        }
    }
}