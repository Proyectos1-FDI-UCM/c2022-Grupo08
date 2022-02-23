using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private Vector3 _distance = new Vector3(0, 1.0f, 2.0f); // Distancia del jugador a la cámara
    [SerializeField]
    private float _factorDeDelay = 1.0f; // Delay entre el movimiento del jugador y el movimiento de la cámara
    [SerializeField]
    private float _distanceToCenter = 1.0f; // Distancia del jugador al centro de la pantalla para dar mejor sensación
    #endregion

    #region properties
    private bool _inTheLimit = false;
    #endregion

    #region references
    [SerializeField]
    private GameObject _targetObject; // Objeto al que siga la camara (será el jugador)
    private Transform _targetObjectTransform;
    /*[SerializeField]
    private GameObject _limits;
    private Transform _limitsTransform;*/
    private Transform _myTransform;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        //_limitsTransform = _limits.transform;
        _targetObjectTransform = _targetObject.transform;
        _myTransform.position = new Vector3(_targetObjectTransform.position.x, _targetObjectTransform.position.y, _myTransform.position.z);
        //_distance = _myTransform.position - _targetObjectTransform.position; //+ _distance;
        //_myTransform.LookAt(_targetObjectTransform.position + new Vector3(0, _distanceToCenter, 0)); // La cámara mira hacia el player al empezar y le sigue en todo momento
    }                                                                                                // hasta que se acerca a una pared de los límites del mapa

    // Update is called once per frame
    void Update()
    {
        _myTransform.position = Vector3.Lerp(_myTransform.position, new Vector3(Mathf.Clamp(_targetObjectTransform.position.x, -5, 5), Mathf.Clamp(_targetObjectTransform.position.y, -5, 5), _myTransform.position.z), Time.deltaTime * _factorDeDelay); // Interpolación linel
    }
}
