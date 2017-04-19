using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour {  
    
    public float zoomSpeed = 5.0f; 

    void LateUpdate()
    {
        float input = -1 * Input.GetAxis("Mouse ScrollWheel");
        if (input != 0)         
            Camera.main.fieldOfView += input * zoomSpeed;         
    }
}
