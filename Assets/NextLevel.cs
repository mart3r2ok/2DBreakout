using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
        public void LoadNextLevel()
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            int nextIndex = currentIndex + 1;

            if (nextIndex < SceneManager.sceneCountInBuildSettings)
            {
                // Сохраняем, что игрок дошёл до следующего уровня
                PlayerPrefs.SetInt("SavedLevel", nextIndex);
                PlayerPrefs.Save();

                SceneManager.LoadScene(nextIndex);
            }
            else
            {
                // Если уровни закончились — можно сбросить прогресс
                PlayerPrefs.SetInt("SavedLevel", 0);
                PlayerPrefs.Save();

                SceneManager.LoadScene(0);
            }
        }
}
