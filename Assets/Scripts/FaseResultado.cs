using System.Collections;
using System.Linq; 
using System.Collections.Generic;
using UnityEngine;

public class FaseResultado : MonoBehaviour
{

    public List<GameObject> enfermedadSeleccionada;
    public List<GameObject> enfermedadReal;
    public List<GameObject> medicamentoSeleccionado;
    public List<GameObject> medicamentoReal;
    public Persona persona;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetSelectedOptions()
	{

        enfermedadSeleccionada.ForEach(enfermedad =>
        {
			if (enfermedad.name.Equals(EnfermedadManager.instance.enfermedadSeleccionada.nombre))
			{
                enfermedad.transform.GetChild(1).gameObject.SetActive(false);
			}
        });

        enfermedadReal.ForEach(enfermedad =>
        {
            if (enfermedad.name.Equals(persona.Enfermedad.nombre))
            {
                enfermedad.transform.GetChild(1).gameObject.SetActive(false);
            }
        });
    }

}
