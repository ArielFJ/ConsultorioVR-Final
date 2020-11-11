using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/Enfermedad")]
public class Enfermedad : ScriptableObject
{
    public string nombre = "Gripe";
    public List<Sintomas> SintomasVerdaderos = new List<Sintomas>();
    public List<Sintomas> SintomasFalsos = new List<Sintomas>();
    public List<Medicamento> Medicamentos = new List<Medicamento>();

    // Formatea el sintoma a un texto formateado legible
    // Ej: DolorDeCabeza -> Dolor De Cabeza
    // Se volvio estatico el metodo para que se pueda acceder de manera mas sencilla en otros scripts
    public static string SintomaToString(Sintomas sintoma)
    {
        string text = sintoma.ToString();
        char[] charArray = text.ToCharArray();
        string toReturn = "";
        for (int i = 0; i < charArray.Length; i++)
        {
            toReturn += char.IsUpper(charArray[i]) ? $" {charArray[i]}" : $"{charArray[i]}";   
        }
        return toReturn.Trim();
    }

}
