using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detección de movimiento WASD
        if (Input.GetKey(KeyCode.W))
        {
            // Arriba
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Abajo
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Izquierda
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Derecha
        }

        // Interacción con objetos
        if (Input.GetKey(KeyCode.E))
        {

        }

        // Selección de armas
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // Palanca
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            // Pistola
        }

        else if (Input.GetKey(KeyCode.Alpha3))
        {
            // Escopeta
        }

        // Disparo

        if (Input.GetKey(KeyCode.Mouse0))
        {

        }
    }
}
