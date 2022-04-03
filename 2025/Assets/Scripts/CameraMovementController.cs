using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    #region parameters
    [SerializeField] private float _delayFactor = 1.0f; // Delay entre el movimiento del jugador y el movimiento de la c�mara
    #endregion

    #region references
    [SerializeField] private Transform _leftDownLimit;
    [SerializeField] private Transform _rightTopLimit;

    //[SerializeField] private GameObject _targetObject; // Objeto al que siga la camara (ser� el jugador)
    private Transform _targetObjectTransform;
    private Transform _myTransform;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
        _targetObjectTransform = GameManager.Instance._player.transform;
    }                                                                                               

    // Update is called once per frame
    void Update()
    {
        _myTransform.position = Vector3.Lerp(_myTransform.position, new Vector3(Mathf.Clamp(_targetObjectTransform.position.x, _leftDownLimit.position.x, _rightTopLimit.position.x), Mathf.Clamp(_targetObjectTransform.position.y, _leftDownLimit.position.y, _rightTopLimit.position.y), _myTransform.position.z), Time.deltaTime * _delayFactor); // Interpolaci�n lineal
    }
}
