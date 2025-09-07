using UnityEngine;

public class Balldisap : MonoBehaviour
{
    public GameManager gameManager;
    public PlatformMove platf;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger сработал с: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ёто шарик, удал€ю...");
            platf.Destroy2(collision.gameObject);
            gameManager.balls--;
            gameManager.check();
        }
    }
}
