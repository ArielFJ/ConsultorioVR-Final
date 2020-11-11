using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pac : MonoBehaviour
{
    public float tempInCelsius;
    float tempInFaren;

    // Start is called before the first frame update
    void Start()
    {
        tempInFaren = (tempInCelsius * 1.8f) + 32f;
    }

    public float GetCelsius() 
    {
        return tempInCelsius;
    }

    public float GetFarenheit() 
    {
        return tempInFaren;  
    }


}
