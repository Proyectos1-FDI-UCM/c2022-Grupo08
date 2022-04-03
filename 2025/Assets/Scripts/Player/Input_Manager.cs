using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    #region parameters
    public int dir;
    #endregion
    #region properties
    [HideInInspector] public bool InDetectionZone = false; // Booleano que detecta si se está dentro de la zona de interacción con algun objeto interactuable
    public bool _isDead = false;
    public bool _leverActivated = false; //Palanca
    public bool _pistolaActivada = false;
    public bool _escopetaActivada = false;
    #endregion
    #region references
    private Player_MovementController _myPlayerMovementController;
    private Player_Attack _myPlayerAttack;
    private Player_Interact _myPlayerInteract;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myPlayerMovementController = GetComponent<Player_MovementController>();
        _myPlayerAttack = GetComponent<Player_Attack>();
        _myPlayerInteract = GetComponent<Player_Interact>();        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = Vector3.zero;

        // Detección de movimiento WASD
        if (!_isDead && !GameManager.Instance.IsGamePaused)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // Arriba
                movementDirection.y = 1.0f;
                dir = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                // Abajo
                movementDirection.y = -1.0f;
                dir = 2;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                // Izquierda
                movementDirection.x = -1.0f;
                dir = 3;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                // Derecha
                movementDirection.x = 1.0f;
                dir = 4;
            }
            _myPlayerMovementController.SetDirection(movementDirection);

            // Interacción con objetos
            if (InDetectionZone)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _myPlayerInteract.ToCallInteraction(); // Cambia booleano del script attack
                }
            }

            // Selección de armas
            if (_leverActivated)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _myPlayerAttack.ShootBala(1,dir);
                }
            }
            if (_pistolaActivada)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    _myPlayerAttack.ShootBala(2, dir);
                }
            }

            if (_escopetaActivada)
            {
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    _myPlayerAttack.ShootBala(3, dir);
                }
            }

            // Menu pausa
            /*if (Input.GetKeyDown(KeyCode.Q))
            {
                GameManager.Instance.PauseGame();
            }*/
        }
    }
}
