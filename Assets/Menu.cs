using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void SceneStart()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
