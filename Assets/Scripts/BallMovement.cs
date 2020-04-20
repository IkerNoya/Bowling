﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public List<GameObject> pins = new List<GameObject>();

    float forceReleased = 0;
    float timer = 0;
    float timerEnd = 0;
    float pinsleft = 0;
    public float force;
    public float forceLimit;
    public Rigidbody ball;
    public Collider Pit;
    float horizontal;
    public float shotsLeft;

    public float timerLimit;
    float timerEndLimit = 5;
    Vector3 initialPos;
    Vector3 movement;
    public float horizontalMovementSpeed;
    bool startTimer = false;

    public Text forceText;
    public Text pinsText;
    public Text shotsText;

    void Start()
    {
        for (int i = 0; i < pins.Count; i++)
        {
            if (pins[i].transform.localRotation == Quaternion.Euler(0, 0, 0))
            {
                pinsleft++;
            }
        }
        initialPos = new Vector3(2, 3, -20);
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        movement = new Vector3(horizontal, 0, 0) * horizontalMovementSpeed;

        transform.position += movement * Time.deltaTime;

        if(Input.GetKeyUp(KeyCode.UpArrow) && forceReleased < forceLimit)
        {
            forceReleased += force;    
            Debug.Log(forceReleased);
        }else if(Input.GetKeyUp(KeyCode.DownArrow) && forceReleased < forceLimit)
        {
            forceReleased -= force;    
            Debug.Log(forceReleased);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            ball.AddForce(Vector3.forward * forceReleased);
            shotsLeft--;
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

        forceText.text = "Force: " + forceReleased.ToString();
        pinsText.text = "Pins: " + pinsleft.ToString();
        shotsText.text = "Shots Left: " + shotsLeft.ToString();

        if(shotsLeft <= 0 || pinsleft <= 0)
        {
            timerEnd += Time.deltaTime;
            if (timerEnd >= timerEndLimit)
            {
                timerEnd = 0;
                SceneManager.LoadScene("End");
            }
        }
    }
    void OnTriggerEnter(Collider Pit)
    {
        startTimer = true;
    }
    void OnTriggerExit(Collider Pit)
    {
        startTimer = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < pins.Count; i++)
        {

            if (((collision.gameObject == pins[i] && pins[i].GetComponent<Pin>().isAlive == true) || pins[i].transform.localPosition.y < -10) && pins[i].GetComponent<Pin>().dead == false)   
            {
                pinsleft--;
                pins[i].GetComponent<Pin>().dead = true;
                if (pinsleft<0)
                {
                    pinsleft = 0;
                }
            }
        }
    }

}
