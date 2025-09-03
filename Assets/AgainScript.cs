using UnityEngine;
using UnityEngine.SceneManagement;
public class AgainScript : MonoBehaviour
{
    public void StartScene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
