using UnityEngine;
using UnityEngine.SceneManagement;
public class NewGameScr : MonoBehaviour
{
    public GameObject menu;
    public GameObject Levelmenu;
    public GameObject BB;
       public void NewGame()
    {
        PlayerPrefs.SetInt("SavedLevel", 1); 
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }
    public void ContinueGame()
    {
        int savedLevel = PlayerPrefs.GetInt("SavedLevel", 1);
        SceneManager.LoadScene(savedLevel);
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
}
