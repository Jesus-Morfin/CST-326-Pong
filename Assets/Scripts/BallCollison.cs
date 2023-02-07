using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 using UnityEngine.SceneManagement;

public class BallCollison : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject ball;
    public TextMeshProUGUI LeftcountText;
    public TextMeshProUGUI RightcountText;
    public float speed = 20;
    public Vector3 impulse;

    private int rightCount;
    private int leftCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(impulse, ForceMode.Impulse);

        leftCount = 0;
        rightCount = 0;

        //SetCountText();
    }

    

/*
    void SetCountText()
    {
       // LeftcountText.text += leftCount.ToString();
        if(leftCount >= 11)
        {
            Debug.Log("Game Over Left Player Wins");
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }

        //RightcountText.text += rightCount.ToString();
        if(rightCount >= 11)
        {
            Debug.Log("Game Over Right Player Wins");
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }

        
    }*/

    public void ReturnToCentertoRight()
    {
        ball = GameObject.FindWithTag("Ball");
        transform.position = new Vector3(1 ,1, 0);
        rb.AddForce(new Vector3(-4, 0, -4)*speed);
    }
    
    public void ReturnToCentertoLeft()
    {
        ball = GameObject.FindWithTag("Ball");
        transform.position = new Vector3(1 ,1, 0);
        rb.AddForce(new Vector3(4, 0, 4)*speed);
    
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RightGoal"))
        {
            leftCount = leftCount + 1;
            Debug.Log("Left Player Scores "+ leftCount +"/"+rightCount);
            if(leftCount >= 11)
        {
            Debug.Log("Game Over Left Player Wins");
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
            ReturnToCentertoRight();
        }

        if(other.gameObject.CompareTag("LeftGoal"))
        {
            rightCount = rightCount + 1;
             Debug.Log("Right Player Scores "+ leftCount +"/"+rightCount);
            if(rightCount >= 11)
        {
            Debug.Log("Game Over Right Player Wins");
            SceneManager.LoadScene( SceneManager.GetActiveScene().name );
        }
            ReturnToCentertoLeft();
        }
    }



}
