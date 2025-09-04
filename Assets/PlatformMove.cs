using Unity.VisualScripting;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 7f;
    private int direction = 0; // -1 = влево, 1 = вправо, 0 = стоит
    public GameObject prefabBall;
    public GameManager gameManager;
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PB"))
        {
            Instantiate(prefabBall, new Vector3(other.gameObject.transform.position.x - 2, other.gameObject.transform.position.y + 1, other.gameObject.transform.position.z), Quaternion.identity);
            Instantiate(prefabBall, new Vector3(other.gameObject.transform.position.x + 2, other.gameObject.transform.position.y + 1, other.gameObject.transform.position.z), Quaternion.identity);
            Destroy(other.gameObject);
            gameManager.balls+=2;
        }
    }
}