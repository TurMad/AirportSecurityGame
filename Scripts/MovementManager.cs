using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject[] wayPoints;
    public bool canMoveToPosition;
    public bool stayInPosition;
    public bool isChecking;
    public float moveSpeed;
    public float rotationSpeed;
    GameManager GM;
    public int wayPointIndex;

    Animator customerAnimator;
    private void Awake()
    {
        customerAnimator = GetComponent<Animator>();
        GM = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        MoveToPosition();
        AnimationCheck();
    }
    private void MoveToPosition()
    {
        if (canMoveToPosition)  
        {
            stayInPosition = false;
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[wayPointIndex].transform.position, moveSpeed * Time.deltaTime);  
            transform.rotation = Quaternion.Lerp(transform.rotation, wayPoints[wayPointIndex].transform.rotation, rotationSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, wayPoints[wayPointIndex].transform.position) <= 0)
            {
                if (GM.canvasIndex >= 2)
                {
                    isChecking = true;
                }
                canMoveToPosition = false;
                stayInPosition = true;
                GM.canShowCanvas = true;
                wayPointIndex++;
            }
        }
     }

    private void AnimationCheck()
    {
        if (!stayInPosition)
        {
            customerAnimator.SetBool("isWalk", true);
        }
        else if(stayInPosition && isChecking)
        {
            customerAnimator.SetBool("isChecking", true);
        }
        else
        {
            customerAnimator.SetBool("isWalk", false);
        }
    }
}
