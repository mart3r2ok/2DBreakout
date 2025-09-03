using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 7f;
    private int direction = 0; // -1 = влево, 1 = вправо, 0 = стоит
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = -1;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = 1;
        float newX = transform.position.x + direction * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, -10.303f, 10.303f);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
   
}