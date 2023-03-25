using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstCanvas : MonoBehaviour
{
    [SerializeField] Image cusImage;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI birthDate;
    [SerializeField] TextMeshProUGUI expirtyDate;
    [SerializeField] TextMeshProUGUI boardingPassName;
    [SerializeField] TextMeshProUGUI flightNumber;

    public void GetCustomerInfo(Sprite image, string name, string birth, string expirty, string bpName, string fNumber)
    {
        cusImage.sprite = image;
        nameText.text = name;
        birthDate.text = birth;
        expirtyDate.text = expirty;
        boardingPassName.text = bpName;
        flightNumber.text = fNumber;
    }
}
