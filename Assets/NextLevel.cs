using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
