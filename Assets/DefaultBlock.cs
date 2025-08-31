using UnityEngine;

public class DefaultBlock : MonoBehaviour
{
    public GameManager gameManager;
    public int countBlocks = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
            gameManager.check(++countBlocks);
        }
    }
}
