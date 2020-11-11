using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porcentaje : MonoBehaviour
{
    private Slider slider; 
   
    public float porciento=1;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }


  
    private void Update()
    {
        slider.value = porciento;
    }




}
