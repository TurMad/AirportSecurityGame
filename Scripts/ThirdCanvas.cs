using UnityEngine;
using UnityEngine.UI;

public class ThirdCanvas : MonoBehaviour
{
    [SerializeField] Image[] images;
    [SerializeField] Sprite newButtonSprite;
    [SerializeField] Color color;
    
    public void NewButtonImage()
    {
        foreach (var image in images)
        {
            image.sprite = newButtonSprite;
            image.color = color;
        }
    }


}
