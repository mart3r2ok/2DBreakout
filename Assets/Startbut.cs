using UnityEngine;

public class Startbut : MonoBehaviour
{
    public MonoBehaviour Ballmove;
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            gameObject.SetActive(false);
            Ballmove.enabled = true;
        }
    }
}
