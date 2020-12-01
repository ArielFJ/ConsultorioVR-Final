using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionWhenCollide : MonoBehaviour
{
    public GameObject[] barreras;
    private Transform initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform;
    }


    // Reinicia la posición del objeto en caso de chocar con barrera
    private void OnCollisionEnter(Collision collision)
    {
        foreach(var go in barreras)
        {
            if (collision.gameObject.Equals(go))
            {
                transform.position = initialPosition.position;
            }
        }
    }
}
