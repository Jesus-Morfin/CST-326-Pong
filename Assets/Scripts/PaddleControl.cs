using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    
    public bool leftPaddle;
    public int score;
    public float speed = 100f;
    public Rigidbody rb;
    private float movement;



    private void FixedUpdate()
    {
        movement = 0f;
        if(leftPaddle)
        {
            //The GetAxisRaw name has to match with the input Manager name
            float movement = Input.GetAxisRaw("LeftPaddle");
            Vector3 force = Vector3.right * movement * speed * Time.deltaTime;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.Force);
        }
        else
        {
            float movement = Input.GetAxisRaw("RightPaddle");

            Vector3 force = Vector3.left * movement * speed * Time.deltaTime;

            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.Force);
        }
        transform.position += new Vector3(0f, 0f, movement * speed * Time.deltaTime);
    }
 
 
}
