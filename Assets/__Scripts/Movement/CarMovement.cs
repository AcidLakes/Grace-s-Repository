using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        
        transform.Translate(5*Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        //transform.Rotate(0.2f, 0, 0);
    }
}
