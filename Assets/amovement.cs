using UnityEngine;

public class amovement : MonoBehaviour
{

    void Update()
    {
        gameObject.transform.Translate(0, -0.01f, 0);
    }
}
