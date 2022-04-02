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
    private Transform _playerTransform;

    [SerializeField]
    private Transform _enemy;

    [SerializeField]
    private int _distanceToDetection;

    private float changeDistance = 0.1f; // distancia minima a la que el jugador cambiará su objetivo al siguiente punto
 
    private int nextPosition = 0; // posicion

    private int currentPosition = 0;

    private bool deteccion = false; //Bool para la animación
    #endregion

    #region references
    private Transform _myTransform;
    
    [SerializeField]
    private Animator _myAnimator;
    private Life_Component _myLifeComponent;
    private AudioSource _Zombie;
    #endregion

    #region methods
    private void DeteccionPlayer()
    {
        _myTransform.position = Vector2.MoveTowards(_myTransform.position, _playerTransform.position, velocity * Time.deltaTime);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _myLifeComponent = GetComponent<Life_Component>();
        _playerTransform = GameManager.Instance._player.transform;
        _Zombie = GetComponent<AudioSource>();
        if (SoundManager.Instance.zombieMuted)
        {
            _Zombie.mute = false;
        }
        else
        {
            _Zombie.mute = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsGamePaused && !_myLifeComponent._isDead)
        {
            if (Vector2.Distance(_myTransform.position, _playerTransform.position) <= _distanceToDetection) // si la distancia entre player y enemy es menor que 5, sigue al player
            {
                DeteccionPlayer();
                deteccion = true;
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
                deteccion = false;
            }
        }
        //Animación
        _myAnimator.SetFloat("Punto1", currentPosition);
        _myAnimator.SetFloat("Punto2", nextPosition);
        _myAnimator.SetFloat("Puntox", _playerTransform.position.x - _enemy.position.x);
        _myAnimator.SetFloat("Puntoy", _playerTransform.position.y - _enemy.position.y);
        _myAnimator.SetBool("Jugador", deteccion);
    }
}
