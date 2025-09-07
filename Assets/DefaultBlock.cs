using UnityEngine;

public class DefaultBlock : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject prefab1; // задать в инспекторе
    public GameObject prefab2; // задать в инспекторе
    private int y;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // отражаем шар
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 reflectDir = Vector2.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(reflectDir * 8f, ForceMode2D.Impulse);
            }

            // шанс на спавн
            int x = Random.Range(1, 6);
            if (x == 1)
            {
                y = Random.Range(1, 3);
                if (y == 1)
                    Instantiate(prefab1, transform.position, Quaternion.identity);
                else
                    Instantiate(prefab2, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);

            gameManager.countBlocks++;
            gameManager.check();
        }
    }
}