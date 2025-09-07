using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float balls = 1f;
    public float countBlocks = 0f;
    public GameObject Panellose;
    public GameObject Panelwin;
    public PlatformMove platformMove;
    public BallMovement ballMovement;
    void Start()
    {
        platformMove = GameObject.FindGameObjectWithTag("Paddle").GetComponent<PlatformMove>();
        ballMovement = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallMovement>();
    }

    void Update()
    {
        
    }
    public void check()
    {
        if(balls == 0)
        {
            platformMove.enabled = false;
            Panellose.SetActive(true);
        }
        if (countBlocks == 126)
        {
            ballMovement.enabled = false;
            platformMove.enabled = false;
            Panelwin.SetActive(true);
        }
    }
}
