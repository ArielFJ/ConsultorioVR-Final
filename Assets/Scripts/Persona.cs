using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Persona : MonoBehaviour
{

    public Alergia[] alergiasCliente;
    public string Nombre = "Jose Lopez";
    public int Edad = 25;
    public char Sexo = 'M';
    public string Peso = "180.0lb";
    public string Altura = "1.80m";
    public string TipoSangre = "+A";


    private void Start()
    {
        //alergiasCliente = new Alergia[2];
        //// Ciclo para agregar 2 alergias de manera aleatoria al arreglo.
        //for (int i = 0; i < 2; i++)
        //{
        //    Alergia primeraAlergia = (Alergia)UnityEngine.Random.Range(0, Enum.GetNames(typeof(Alergia)).Length);

        //    if (!alergiasCliente.Contains(primeraAlergia))
        //    {
        //        alergiasCliente[i] = primeraAlergia;
        //    }
        //    else
        //    {
        //        i--;
        //    }


        //}
    }

}
