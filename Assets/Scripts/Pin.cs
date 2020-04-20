using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isAlive = true;
    public bool dead = false;

    // Update is called once per frame
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
    }
}
