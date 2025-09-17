using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float balls = 1f;
    public int k;
    public float countBlocks = 0f;
    public GameObject Panellose;
    public GameObject Panelwin;
    public PlatformMove platformMove;
    public float maxBlocks;
    public string levelName;
    public AudioSource bgm;
    public float timer = 0f;
    void Start()
    {
        platformMove = GameObject.FindGameObjectWithTag("Paddle").GetComponent<PlatformMove>();
        levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        k = (levelName == "Level1") ? 1 : 2;
        if (k == 1) maxBlocks = 126f;
        if (k == 2) maxBlocks = 159f;
    }

    void Update()
    {
        if(countBlocks == 125 && k == 1)
        {
            timer += Time.deltaTime;
        }
        check();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void check()
    {
        if(balls <= 0)
        {
            bgm.Stop();
            platformMove.enabled = false;
            Panellose.SetActive(true);
        }
        if (countBlocks >= maxBlocks)
        {
            bgm.Stop();
            platformMove.enabled = false;
            Panelwin.SetActive(true);
        }
        if(k == 1 && timer > 15 && countBlocks == 125)
        {
            countBlocks = 126;
        }
    }
}
