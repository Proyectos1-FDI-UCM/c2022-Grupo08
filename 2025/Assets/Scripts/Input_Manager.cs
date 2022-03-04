using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    #region properties
    [HideInInspector]
    public bool InDetectionZone = false; // Booleano que detecta si se está dentro de la zona de interacción con algun objeto interactuable
    public bool _isDead = false;
    #endregion

    #region references
    private Player_MovementController _myPlayerMovementController;
    private Player_Attack _myPlayerAttack;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myPlayerMovementController = GetComponent<Player_MovementController>();
        _myPlayerAttack = GetComponent<Player_Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;

        // Detección de movimiento WASD
        if (!_isDead)
        {
            Debug.Log(_isDead);
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

            _myPlayerMovementController.SetDirection(movementDirection);

            // Interacción con objetos
            if (InDetectionZone)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _myPlayerAttack.ToCallInteraction(); // Cambia booleano del script attack
                }
            }

            // Selección de armas
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _myPlayerAttack.ShootBala(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _myPlayerAttack.ShootBala(2);
            }

            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _myPlayerAttack.ShootBala(3);
            }
        }
    }
        
}
