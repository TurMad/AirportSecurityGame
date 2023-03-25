using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
   public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowRules()
    {

    }

    public void LevelMeun()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}
