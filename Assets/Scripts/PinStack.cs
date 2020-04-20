using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinStack : MonoBehaviour
{

    public List<GameObject> Pins = new List<GameObject>();
    public Vector3[] initialPos;
    public Quaternion initialRot;
    public Rigidbody[] pinPhysics;
    void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            initialPos[i] = Pins[i].transform.localPosition;
            pinPhysics[i] = Pins[i].GetComponent<Rigidbody>();
        }

    }
    void Start()
    {
        initialRot = Quaternion.Euler(0, 0, 0);
    }
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            for (int i = 0; i < 10; i++)
            {
                Pins[i].transform.localPosition = initialPos[i];
                Pins[i].transform.localRotation = initialRot;
                pinPhysics[i].velocity = Vector3.zero;
                pinPhysics[i].angularVelocity = Vector3.zero;
            }
        }
    }
    
}
