using UnityEngine;
using UnityEngine.UI;

public class SecondCanvas : MonoBehaviour
{
    [SerializeField] Image bagImage;

    public void GetBagImage(Sprite image)
    {
        bagImage.sprite = image;
    }
}
