using UnityEngine;
using UnityEngine.UI;

public class LevelScene : MonoBehaviour
{
    public Button[] buttons;
    

    private void Start()
    {
        int levelOpened = PlayerPrefs.GetInt("levelOpened", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            if(i + 1 > levelOpened)
            {
                buttons[i].interactable = false;
            }
        }
    }

}
