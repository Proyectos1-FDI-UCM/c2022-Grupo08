using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDetection : MonoBehaviour
{
    /*#region parameters
    [SerializeField]
    private float _detectionDistance = 2.0f;
    #endregion


    #region properties
    private float _distance;
    #endregion
    */
    #region references
    /*
    [SerializeField]
    private GameObject _targetObject; // Objecto que si se acerca permito interacción (player)
    private Transform _myTransformTarget; // Transform del target
    private Input_Manager _myInputManager; // Input del player
    private Transform _myTransform; // Transform del objeto interactuable*/
    #endregion

    #region methods
    public void Interact()
    {
        GameManager.Instance.InteractableObjectDone(this); // Llamo al GameManager para eliminar de escena el objeto con el que ya he interactuado
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        /*_myTransform = transform;
        _myTransformTarget = _targetObject.transform;
        _myInputManager = _targetObject.GetComponent<Input_Manager>();*/
    }

    // Update is called once per frame
    void Update()
    {
        // Distancia entre 2 puntos en el espacio
        //_distance = Mathf.Sqrt(Mathf.Pow(_myTransform.position.x - _myTransformTarget.position.x, 2) + Mathf.Pow(_myTransform.position.y - _myTransformTarget.position.y, 2) + Mathf.Pow(_myTransform.position.z - _myTransformTarget.position.z, 2));
        /*_distance = Vector3.Distance(_myTransform.position, _myTransformTarget.position);
        if (_distance < _detectionDistance)
        {
            //Debug.Log("Hola");
            _myInputManager.InDetectionZone = true;
        }
        else
        {
            //Debug.Log("Adios");
            _myInputManager.InDetectionZone = false;
        }*/
    }
}
