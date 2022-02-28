using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    #region parameters
    [SerializeField]
    List<Transform> wayPoints;

    [SerializeField]
    private float velocity = 2.0f;

    [SerializeField]
    private Transform _player;
    
    private float changeDistance = 0.1f; // distancia minima a la que el jugador cambiará su objetivo al siguiente punto
 
    private int nextPosition = 0; // posicion

    private int currentPosition = 0;
    #endregion

    #region references
    private Transform _myTransform;
    [SerializeField]
    private Animator _myAnimator;
    #endregion

    #region methods
    private void DeteccionPlayer()
    {
        _myTransform.position = Vector2.MoveTowards(_myTransform.position, _player.transform.position, velocity * Time.deltaTime);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;       
    }

    // Update is called once per frame
    void Update()
    {      
        if (Vector2.Distance(_myTransform.position, _player.transform.position) <= 5) // si la distancia entre player y enemy es menor que 5, sigue al player
        { 
            DeteccionPlayer(); 
        } 
        else
        {
            _myTransform.position = Vector3.MoveTowards(_myTransform.position, wayPoints[nextPosition].transform.position, velocity * Time.deltaTime);
            if (Vector3.Distance(_myTransform.position, wayPoints[nextPosition].transform.position) <= changeDistance) // si la distancia es menor a la distancia de cambio, se pasa al siguiente waypoint
            {
                currentPosition = nextPosition;
                nextPosition++;

                if (nextPosition >= wayPoints.Count)
                {
                    nextPosition = 0;
                }
            }
        }
        //Animación
        _myAnimator.SetInteger("Posicion", currentPosition);
        _myAnimator.SetInteger("Siguiente", nextPosition);
    }
}
