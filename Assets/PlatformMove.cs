using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 7f;
    public GameObject prefabBall;
    public GameObject FBall;
    public GameManager gameManager;

    private List<GameObject> spawnedBlocks = new List<GameObject>();

    void Start()
    {
        spawnedBlocks.Add(FBall);
    }

    void Update()
    {
        float direction = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            direction = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            direction = 1f;

        float newX = transform.position.x + direction * speed * Time.deltaTime;
        newX = Mathf.Clamp(newX, -10.303f, 10.303f);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PB"))
        {
            SpawnBallsAround(other.transform.position, 2f, 1f);
            Destroy(other.gameObject);
            gameManager.balls += 2;
        }
        else if (other.CompareTag("PBU"))
        {
            Destroy(other.gameObject);
            gameManager.balls *= 3;

            // Сначала собираем все позиции, потом создаём шары
            List<Vector3> newPositions = new List<Vector3>();
            foreach (var block in spawnedBlocks)
            {
                Vector3 pos = block.transform.position;
                newPositions.Add(pos + Vector3.left * 2f);
                newPositions.Add(pos + Vector3.right * 2f);
            }

            foreach (var pos in newPositions)
            {
                if (gameManager.balls <= 150)
                {
                    if(pos.x < -10.935f) continue;
                    if(pos.x > 10.935f) continue;
                    if(spawnedBlocks.Count >= 150) break;
                    if(pos.y > 5f) continue;
                    if(pos.y < -5f) continue;
                    GameObject ball = Instantiate(prefabBall, pos, Quaternion.identity);
                    spawnedBlocks.Add(ball);
                }
            }
        }
    }

    private void SpawnBallsAround(Vector3 center, float xOffset, float yOffset)
    {
        Vector3 leftPos = new Vector3(center.x - xOffset, center.y + yOffset, center.z);
        Vector3 rightPos = new Vector3(center.x + xOffset, center.y + yOffset, center.z);
        if(leftPos.x < -10.935f) leftPos.x = -10.935f;
        GameObject ballLeft = Instantiate(prefabBall, leftPos, Quaternion.identity);
        if(rightPos.x > 10.935f) rightPos.x = 10.935f;
        GameObject ballRight = Instantiate(prefabBall, rightPos, Quaternion.identity);

        spawnedBlocks.Add(ballLeft);
        spawnedBlocks.Add(ballRight);
    }

    public void Destroy2(GameObject obj)
    {
        int i = spawnedBlocks.IndexOf(obj);
        if (i != -1)
        {
            int last = spawnedBlocks.Count - 1;
            spawnedBlocks[i] = spawnedBlocks[last];
            spawnedBlocks.RemoveAt(last);
        }
        Destroy(obj);
    }
}