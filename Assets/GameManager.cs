using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void check(int countBlocks)
    {
        if (countBlocks == 36)
        {
            Debug.Log("You win!");
        }
    }
}
