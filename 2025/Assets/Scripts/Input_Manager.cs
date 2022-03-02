using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    #region references
    private Player_MovementController _myplayermovementcontroller ;
    private Player_Attack _myplayerattack;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myplayermovementcontroller = GetComponent<Player_MovementController>();
        _myplayerattack = GetComponent<Player_Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;
        // Detección de movimiento WASD
        if (Input.GetKey(KeyCode.W))
        {
            // Arriba
            movementDirection.y = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            // Abajo
            movementDirection.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // Izquierda
            movementDirection.x = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Derecha
            movementDirection.x = 1.0f;
        }

        _myplayermovementcontroller.SetDirection(movementDirection);

        // Interacción con objetos
        if (Input.GetKey(KeyCode.E))
        {

        }

        // Selección de armas
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _myplayerattack.ShootBala(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _myplayerattack.ShootBala(2);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _myplayerattack.ShootBala(3);
        }
    }
}
