using UnityEngine;
using System.Collections;

public class DefaultBlock : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject prefab1;
    public GameObject prefab2;

    private bool counted = false;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !counted)
        {
            counted = true;

            // сразу отключаем коллайдер и визуал
            Collider2D col = GetComponent<Collider2D>();
            if (col != null) col.enabled = false;

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = false;

            // отскок для шара
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 reflectDir = Vector2.Reflect(rb.linearVelocity.normalized, collision.contacts[0].normal);
                rb.linearVelocity = reflectDir * rb.linearVelocity.magnitude;
            }

            // шанс на спавн
            int x = Random.Range(1, 6);
            if (x == 1)
            {
                int y = Random.Range(1, 3);
                Instantiate(y == 1 ? prefab1 : prefab2, transform.position, Quaternion.identity);
            }

            // запускаем корутину с задержкой
            StartCoroutine(DestroyBlockDelayed());
        }
    }

    private IEnumerator DestroyBlockDelayed()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        gameManager.countBlocks++;
    }
}