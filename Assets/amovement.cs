using UnityEngine;
using UnityEngine.InputSystem.XR;

public class amovement : MonoBehaviour
{
    public float speed = -0.055f;
    void Update()
    {
        gameObject.transform.Translate(0, speed * Time.deltaTime * 60f, 0);
        if(gameObject.transform.position.y < -8f)
        {
            Destroy(gameObject);
        }
    }
}
