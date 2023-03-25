using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] customers;
    [SerializeField] GameObject startBTN;
    [SerializeField] GameObject[] canvases;
    [SerializeField] CinemachineVirtualCamera[] cameras;
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] Image headButton;
    [SerializeField] Image leftHandButton;
    [SerializeField] Image rightHandButton;
    [SerializeField] Image bodyButton;
    [SerializeField] Image topLegButton;
    [SerializeField] Image bottomLegButton;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] Image firstStar;
    [SerializeField] Image secondStar;
    [SerializeField] Image thirdStar;
    [SerializeField] Sprite fullStar;
    bool dangerCustomer = false;
    public int canvasIndex;
    public bool canShowCanvas;
    GameObject newCustomer;
    CustomerInfo info;
    int customerIndex;
    int finalScore;
    
    private void Awake()
    {
        CreateNewCustomer();
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    private void CreateNewCustomer()
    {
        newCustomer = Instantiate(customers[customerIndex], transform.position, transform.rotation);
        newCustomer.GetComponent<MovementManager>().wayPoints = wayPoints;
        newCustomer.GetComponent<MovementManager>().canMoveToPosition = false;
        SetCanvasInfo();
    }
    private void SetCanvasInfo()
    {
        info = newCustomer.GetComponent<CustomerInfo>();
        canvases[0].GetComponent<FirstCanvas>().GetCustomerInfo(info.customerImage, info.customerName, info.customerDateOfBirth, info.customerDateOfExpirty, info.boardingPassPassangerName, info.flightNumber);
        canvases[1].GetComponent<SecondCanvas>().GetBagImage(info.BaggageImage);
        canvases[2].GetComponent<ThirdCanvas>().NewButtonImage();
    }
    public void StartGame()
    {
        newCustomer.GetComponent<MovementManager>().canMoveToPosition = true;
        startBTN.SetActive(false);
    }
    private void Start()
    {
        canvases[canvasIndex].SetActive(false);
        LookAtCamera();
    }
    private void LookAtCamera()
    {
        foreach (var camera in cameras)
        {
            camera.LookAt = newCustomer.transform;
        }
    }
    private void Update()
    {
        ShowCanvas();
    }
    private void ShowCanvas()
    {
        if (canShowCanvas)
        {
            canvases[canvasIndex].SetActive(true);
        }
    }

    public void PassBTN() 
    {
        canvases[canvasIndex].SetActive(false);
        canShowCanvas = false;
        canvasIndex++;
        if(info.criticalMistake)
        {
            dangerCustomer = true;
        }
        if (canvasIndex < canvases.Length)
        {
            newCustomer.GetComponent<MovementManager>().canMoveToPosition = true;    
        }
        else
        {
            finalScore += info.pointForPass;
            NewSession();
        }
    }

    public void NotPassBTN()
    {
        canvases[canvasIndex].SetActive(false);
        canShowCanvas = false;
        finalScore += info.pointForNotPass;
        NewSession();
    }
    private void NewSession()
    {
        Destroy(newCustomer);
        customerIndex++;
        if(customers.Length <= customerIndex)
        {
            CheckFinalScore();
        }
        else
        {
            CreateNewCustomer();
            LookAtCamera();
            startBTN.SetActive(true);
            canvasIndex = 0;
        }

    }
    public void OnClickHeadButton()
    {
        headButton.sprite = info.HeadCheckImage;
        headButton.color = new Color(255f,255f,255,100f);
    }
    public void OnClickLeftHandButton()
    {
        leftHandButton.sprite = info.LeftHandCheckImage;
        leftHandButton.color = new Color(255f, 255f, 255, 100f);
    }
    public void OnClickRightHandButton()
    {
        rightHandButton.sprite = info.RightHandkImage;
        rightHandButton.color = new Color(255f, 255f, 255, 100f);
    }
    public void OnClickBodyButton()
    {
        bodyButton.sprite = info.BodyCheckImage;
        bodyButton.color = new Color(255f, 255f, 255, 100f);
    }
    public void OnClickTopLegButton()
    {
        topLegButton.sprite = info.TopLegImage;
        topLegButton.color = new Color(255f, 255f, 255, 100f);
    }
    public void OnClickBottomLegButton()
    {
        bottomLegButton.sprite = info.BottomLegImage;
        bottomLegButton.color = new Color(255f, 255f, 255, 100f);
    }

    private void CheckFinalScore()
    {
        if(dangerCustomer || finalScore < 25)
        {
            loseCanvas.SetActive(true);
        }
        else if(finalScore >= 25 && finalScore < 35)
        {
            winCanvas.SetActive(true);
            firstStar.sprite = fullStar;
        }
        else if(finalScore >= 35 && finalScore < 45)
        {
            winCanvas.SetActive(true);
            firstStar.sprite = fullStar;
            secondStar.sprite = fullStar;
        }
        else if(finalScore >= 45)
        {
            winCanvas.SetActive(true);
            firstStar.sprite = fullStar;
            secondStar.sprite = fullStar;
            thirdStar.sprite = fullStar;
        }
    }

}
