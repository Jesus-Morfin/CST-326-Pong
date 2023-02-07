using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalScore : MonoBehaviour
{
    public TextMeshProUGUI LeftcountText;
    public TextMeshProUGUI RightcountText;
    public GameObject ball;

    private int rightCount;
    private int leftCount;
    // Start is called before the first frame update
    void Start()
    {
        leftCount = 0;
        rightCount = 0;

        SetCountText();
    }



    void SetCountText()
    {
        LeftcountText.text = leftCount.ToString();
        if(leftCount >= 11)
        {
            Debug.Log("Game Over Left Player Wins");
        }

        RightcountText.text = rightCount.ToString();
        if(rightCount >= 11)
        {
            Debug.Log("Game Over Right Player Wins");
        }

        
    }






    public void ReturnToCenter()
    {

        transform.position = new Vector3(1 ,2, 0);
    }


     private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RightGoal"))
        {
            other.gameObject.SetActive(false);
            leftCount = leftCount + 1;
            Debug.Log("Left Player Scores");
            SetCountText();

            ball = GameObject.FindWithTag("Ball");
            ReturnToCenter();
           
        }

        if(other.gameObject.CompareTag("LeftGoal"))
        {
            other.gameObject.SetActive(false);
            rightCount = rightCount + 1;
            Debug.Log("Right Player Scores");
            SetCountText();

            ball = GameObject.FindWithTag("Ball");
            ReturnToCenter();
            
        }
    }
}
