using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int k = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextScene = (k == 1) ? k + 1 : 0;

        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
