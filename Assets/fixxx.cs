using UnityEngine;

public class fixxx : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<amovement>().speed+=0.01f;
    }
}
