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
    private Player_Life_Component _myPlayerLifeComponent;
    #endregion

    #region properties
    private Vector3 _movementDirection;
    private float _count;
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
        _myPlayerLifeComponent = GetComponent<Player_Life_Component>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_myPlayerLifeComponent.pushing)
        {
            Vector3 directionVector = (_movementSpeed * _movementDirection);
            playerBody.velocity = directionVector;
        }
        else
        {
            _count += Time.deltaTime;
            if (_count >= 0.9)
            {
                _count = 0;
                _myPlayerLifeComponent.pushing = false;
            }
        }
        
        //Animación
        if (!GameManager.Instance.IsGamePaused)
        {
            _velocityX = Input.GetAxisRaw("Horizontal") * _movementSpeed;
            _velocityZ = Input.GetAxisRaw("Vertical") * _movementSpeed;

            _myAnimator.SetFloat("VelocityX", _velocityX);
            _myAnimator.SetFloat("VelocityZ", _velocityZ);
        }
        else if (GameManager.Instance.IsGamePaused)
        {           
            _velocityX = Input.GetAxisRaw("Horizontal") * 0;
            _velocityZ = Input.GetAxisRaw("Vertical") * 0;

            _myAnimator.SetFloat("VelocityX", _velocityX);
            _myAnimator.SetFloat("VelocityZ", _velocityZ);           
        }
    }
}
