using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float balls = 1f;
    public int k;
    public float countBlocks = 0f;
    public GameObject Panellose;
    public GameObject Panelwin;
    public PlatformMove platformMove;
    public float maxBlocks;
    public BallMovement ballMovement;
    public string levelName;
    void Start()
    {
        platformMove = GameObject.FindGameObjectWithTag("Paddle").GetComponent<PlatformMove>();
        levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        k = (levelName == "Level1") ? 1 : 2;
        if (k == 1) maxBlocks = 126f;
        if (k == 2) maxBlocks = 84f;
    }

    void Update()
    {
        check();
    }
    public void check()
    {
        if(balls <= 0)
        {
            platformMove.enabled = false;
            Panellose.SetActive(true);
        }
        if (countBlocks >= maxBlocks)
        {
            platformMove.enabled = false;
            Panelwin.SetActive(true);
        }
    }
}
