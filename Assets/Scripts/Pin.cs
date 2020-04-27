using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour
{
    public bool isAlive = true;
    public bool dead = false;
    public float pinsLeft = 10;
    public Text pinsText;
    float timerEndLimit = 5;
    float timerEnd = 0;
    // Update is called once per frame
    void Start()
    {
    }
    void Update()
    {
        if (transform.localRotation.z > 45 || transform.localRotation.x > 45)
        {
            isAlive = false;
        }
        else
        {
            isAlive = true;
        }
        if (!isAlive)
        {
            pinsLeft--;
        }
        if (pinsLeft <= 0)
        {
            timerEnd += Time.deltaTime;
            if (timerEnd >= timerEndLimit)
            {
                timerEnd = 0;
                SceneManager.LoadScene("End");
            }
        }
        pinsText.text = "Pins: " + pinsLeft.ToString();
    }
}
