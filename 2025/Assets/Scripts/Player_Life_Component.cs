using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : Life_Component
{
    #region references
    private Rigidbody2D _myRigidBody;
    private Input_Manager _myInputManager;
    private Player_MovementController _myPlayerMovementController;
    private Transform _myTransform;
    #endregion
    
    #region properties
    private float empuje = 5f;
    #endregion

    #region methods
    public override void Damage(int DamagePoints)
    {
        base.Damage(DamagePoints);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy_Behaviour enemigo = collision.gameObject.GetComponent<Enemy_Behaviour>();
        if (enemigo)
        {
            var heading = enemigo.transform.position - _myTransform.position;     
            /*
            var distance = heading.magnitude;
            var direction = heading / distance;
            */
            //Necesitamos la direccion del jugador o del zombie
            _myRigidBody.AddForce(heading * -empuje, ForceMode2D.Impulse);
        }
    }
    #endregion

    // Start is called before the first frame update
    override public void Start()
    {
        base.Start();

        _myRigidBody = GetComponent<Rigidbody2D>();
        _myTransform = GetComponent<Transform>();
        _myInputManager = GetComponent<Input_Manager>();
        _myPlayerMovementController = GetComponent<Player_MovementController>();
    }

    // Update is called once per frame
    override public void Update()
    {
        if (_currentLife <= 0)
        {
            // Para no poder mooverse durante la animación de muerte
            _myInputManager._isDead = true; 
            _myPlayerMovementController._movementSpeed = 0;
            _cont -= Time.deltaTime;
            if (_cont <= 0)
            {
                Die(); //GameManager.Instance.OnPlayerDies();
                _cont = 1.7f;
            }
        }
        _myAnimator.SetInteger("VidaPlayer", _currentLife);
    }
}