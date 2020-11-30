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
    public GameObject A, C, F;
    public Persona persona;


    // Start is called before the first frame update
    void Start()
    {
        persona = Persona.instance;
        GetSelectedOptions();
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

        string[] nombreMedicamentos = MedicamentoManager.instance.medicamentosSeleccionados.Select(x => x.Nombre).ToArray();
        List<GameObject> selectedMeds = new List<GameObject>();
        medicamentoSeleccionado.ForEach(medicamento =>
        {
            if (nombreMedicamentos.Contains(medicamento.name))
            {
                medicamento.transform.GetChild(1).gameObject.SetActive(false);
                selectedMeds.Add(medicamento);
            }
        });

        Medicamento med;
        medicamentoReal.ForEach(medicamento =>
        {
            med = MedicamentoManager.instance.medicamentos.FirstOrDefault(m => m.Nombre == medicamento.name);
            if (MedicamentoManager.instance.CanPatientTakeMedicine(med) == (true, true))
            {
                medicamento.transform.GetChild(1).gameObject.SetActive(false);
            }
        });

        GameObject aActivar = new GameObject();
        foreach(GameObject medicamento in selectedMeds)
        {
            med = MedicamentoManager.instance.medicamentos.FirstOrDefault(m => m.Nombre == medicamento.name);
            if (MedicamentoManager.instance.CanPatientTakeMedicine(med) == (false, false))
            {
                Debug.Log(med.Nombre);
                Debug.Log("F");
                aActivar = F;
                break;
            }
        }

        if(aActivar != F)
		{
            foreach (GameObject medicamento in selectedMeds)
            {
                med = MedicamentoManager.instance.medicamentos.FirstOrDefault(m => m.Nombre == medicamento.name);
                if (MedicamentoManager.instance.CanPatientTakeMedicine(med) == (true, false))
                {
                    aActivar = C;
                    Debug.Log("C");
                }
                else if (MedicamentoManager.instance.CanPatientTakeMedicine(med) == (true, true))
                {
                    aActivar = A;
                    Debug.Log("A");
                    break;
                }
            }
		}

        aActivar.SetActive(true);
    }

}
