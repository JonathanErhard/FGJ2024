using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasWorldSpace : MonoBehaviour
{
    void Start()
    {
        // hard set rotation so it fits the camera angle
        transform.rotation = Quaternion.Euler(45,45,0);
    }
}
