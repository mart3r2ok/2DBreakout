using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGameScr : MonoBehaviour
{
    public GameObject menu;
    public GameObject Levelmenu;
    public GameObject BB;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("LoadGame");
    }
    public void Levels()
    {
        menu.SetActive(false);
        Levelmenu.SetActive(true);
        BB.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Back()
    {
        Levelmenu.SetActive(false);
        menu.SetActive(true);
        BB.SetActive(false);
    }
    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
}
