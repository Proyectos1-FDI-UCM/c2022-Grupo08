using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life_Component : Life_Component
{
    #region references
    private Rigidbody2D _myRigidBody;
    private Input_Manager _myInputManager;
    private Player_MovementController _myPlayerMovementController;
    private Transform _myTransform;

    [SerializeField]
    private GameObject _boy;

    [SerializeField]
    private GameObject _girl;


    public Image _lifeBar;
    #endregion

    #region properties
    [SerializeField]
    private float empuje = 2f; //Fuerza con la que se va a ipulsar hacia atrás al jugador al ser golpeado por un objeto hostil
    [SerializeField] private float empujeZombie = 0.5f;
    #endregion

    #region methods
    public override void Damage(int DamagePoints)
    {
        //_currentLife -= DamagePoints;
        //_myRigidBody.AddForce(_myTransform.position * -empuje, ForceMode2D.Impulse);

         base.Damage(DamagePoints);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy_Behaviour enemigo = collision.gameObject.GetComponent<Enemy_Behaviour>();

        Barricada barricada = collision.gameObject.GetComponent<Barricada>();

        if (enemigo) //Si el objeto con el que colisiona es un enemigo se usa la posición del enemigo para calcular la direccion de empuje
        {
            var heading = enemigo.transform.position - _myTransform.position; //Direccion de empuje    
            //Necesitamos la direccion del jugador o del zombie
            _myRigidBody.AddForce(heading * -empuje, ForceMode2D.Impulse);
            var direction = _myTransform.position - enemigo.transform.position;
            collision.rigidbody.AddForce(direction * -empujeZombie, ForceMode2D.Impulse);
        }

        else if (barricada) //Si el objeto con el que colisiona es la barricada se usa su posicion para calcular la direccion de empuje
        {
            var heading = barricada.transform.position - _myTransform.position; //Direccion de empuje
            //Necesitamos la direccion del jugador o del zombie
            _myRigidBody.AddForce(heading * -empuje / 4, ForceMode2D.Impulse);
        }
    }
    public void Cura(int curacion)
    {
        _currentLife += curacion;
        _currentLife = Mathf.Clamp(_currentLife, 0, 100);
        
    }

    public void BeBoy()
    {
        _boy.SetActive(true);
    }

    public void BeGirl()
    {
        _girl.SetActive(true);
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
        // _instance = this;
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
                GameManager.Instance.LoadGameOverMenu();
                _cont = 1.7f;
                
            }
        }
        //_myAnimator.SetInteger("VidaPlayer", _currentLife);


        _lifeBar.fillAmount = _currentLife / _maxLife;

        //Debug.Log(_currentLife);
        
    }
}