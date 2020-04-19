using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    float forceReleased = 0;
    public float force;
    public float forceLimit;
    public Rigidbody ball;
    public Collider Pit;
    float timer = 0;
    public float timerLimit;
    Vector3 initialPos;
    bool startTimer = false;

    void Start()
    {
        initialPos = new Vector3(2, 3, -20);
    }
    void OnTriggerEnter(Collider Pit)
    {
        startTimer = true;
    }
    void OnTriggerExit(Collider Pit)
    {
        startTimer = false;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && forceReleased < forceLimit)
        {
            forceReleased += force * Time.deltaTime;    
            Debug.Log(forceReleased);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ball.AddForce(Vector3.forward * forceReleased);
        }
        if (startTimer == true)
        {
            ball.velocity = Vector3.zero;
            Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer >= timerLimit)
            {
                ball.velocity = Vector3.zero;
                ball.angularVelocity = Vector3.zero;
                transform.position = initialPos;
                forceReleased = 0;
            }

        }
        else
        {
            timer = 0;
        }
    }

}
