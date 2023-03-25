using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public int levelNumber;
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = levelNumber.ToString();
    }
    public void SelectButton()
    {
        SceneManager.LoadScene("Level" + levelNumber);
    }


}

