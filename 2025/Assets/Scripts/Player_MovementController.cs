using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MovementController : MonoBehaviour
{
    #region parameters
    [SerializeField]
    public float _movementSpeed = 1.0f;
    private float _horizontalMove = 0.0f;
    private float _verticalMove = 0.0f;
    #endregion

    #region references
    private Transform _myTransform;
    #endregion

    #region properties
    private Vector3 _movementDirection;


    #endregion

    #region methods
    public void SetDirection(Vector3 movementDirection)
    {
        _movementDirection = movementDirection.normalized;
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
        _myTransform.Translate(_movementSpeed * _movementDirection * Time.deltaTime);
    }
}
