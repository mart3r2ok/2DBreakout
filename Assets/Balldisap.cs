using UnityEngine;

public class Balldisap : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger �������� �: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("��� �����, ������...");
            Destroy(collision.gameObject);
            gameManager.balls--;
            gameManager.check();
        }
    }
}
