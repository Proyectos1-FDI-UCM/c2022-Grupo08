using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _factorDeDelay = 1.0f; // Delay entre el movimiento del jugador y el movimiento de la c�mara
    [SerializeField]
    private float _distanceToCenter = 1.0f; // Distancia del jugador al centro de la pantalla para dar mejor sensaci�n
    #endregion

    #region references
    [SerializeField]
    private Transform _leftLimit;
    [SerializeField]
    private Transform _rightLimit;
    [SerializeField]
    private Transform _topLimit;
    [SerializeField]
    private Transform _downLimit;

    [SerializeField]
    private GameObject _targetObject; // Objeto al que siga la camara (ser� el jugador)
    private Transform _targetObjectTransform;
    private Transform _myTransform;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _targetObjectTransform = _targetObject.transform;
        _myTransform.position = new Vector3(_targetObjectTransform.position.x, _targetObjectTransform.position.y, _myTransform.position.z);
    }                                                                                               

    // Update is called once per frame
    void Update()
    {
        _myTransform.position = Vector3.Lerp(_myTransform.position, new Vector3(Mathf.Clamp(_targetObjectTransform.position.x, _leftLimit.position.x, _rightLimit.position.x), Mathf.Clamp(_targetObjectTransform.position.y, _downLimit.position.y, _topLimit.position.y), _myTransform.position.z), Time.deltaTime * _factorDeDelay); // Interpolaci�n linel
    }
}
