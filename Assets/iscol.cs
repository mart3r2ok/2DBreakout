using UnityEngine;

public class iscol : MonoBehaviour
{
    public bool b = true;
    public void ifEntrytheBlock(Collider2D other)
    {
        if (other.CompareTag("Ban"))
        {
            b = false;
        }
        else
        {
            b = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        ifEntrytheBlock(other);
    }
}
