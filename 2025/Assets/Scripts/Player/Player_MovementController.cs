using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_MovementController : MonoBehaviour
{
    #region parameters
    [SerializeField] public float _movementSpeed = 1.0f;
    private float _velocityX = 0.0f;
    private float _velocityZ = 0.0f;
    #endregion

    #region references
    private Transform _myTransform;
    [SerializeField] private Animator _myAnimator;
    private Rigidbody2D playerBody;
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
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionVector = (_movementSpeed * _movementDirection );
        playerBody.velocity = directionVector;
        

        //Animación
        if (!GameManager.Instance.IsGamePaused)
        {
            _velocityX = Input.GetAxisRaw("Horizontal") * _movementSpeed;
            _velocityZ = Input.GetAxisRaw("Vertical") * _movementSpeed;

            _myAnimator.SetFloat("VelocityX", _velocityX);
            _myAnimator.SetFloat("VelocityZ", _velocityZ);
        }
    }
}
