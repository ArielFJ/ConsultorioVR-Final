using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Termometro : MonoBehaviour
{
    public Transform firePoint;
    public LineRenderer line;
    public TextMeshProUGUI celciusText;
    public TextMeshProUGUI farenText;
    public GameObject canvas;
    public Material screen;

    public bool isGrabbeb;

    private void Start()
    {
        canvas.SetActive(false);
        screen.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrabbeb)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(Shoot());
            }
        }
        if (!isGrabbeb) 
        {
            canvas.SetActive(false);
            screen.DisableKeyword("_EMISSION");
        }
    }

    IEnumerator Shoot() 
    {
        Debug.Log("shoot");
        canvas.SetActive(true);
        screen.EnableKeyword("_EMISSION");

        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, 50))
        {
            Debug.Log(hit.transform.name);

            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, hit.point);

            //Check si tiene script pciente
            Pac pac = hit.transform.GetComponent<Pac>();
            if (pac) 
            {
                //Busca Temperatura
                //Escribe Temperaturas en el canvas
                celciusText.text = pac.GetCelsius().ToString() + " °C";
                farenText.text = pac.GetFarenheit().ToString()+ " °F";
            }

        }
        else 
        {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.forward * 100);
        }

        line.enabled = true;
        yield return new WaitForSeconds(1f);

        line.enabled = false;


    }
}
