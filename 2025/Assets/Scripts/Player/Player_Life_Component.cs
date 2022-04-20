using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Life_Component : Life_Component
{
    #region references
    private Rigidbody2D _myRigidBody;
    private Player_MovementController _myPlayerMovementController;
    private Transform _myTransform;
    [SerializeField] private GameObject _boy;
    [SerializeField] private GameObject _girl;
    public Image _lifeBar;
    public bool pushing = false;
    public bool _isPlayerDead = false;
    #endregion

    #region properties
    [SerializeField] private float empuje = 2f; //Fuerza con la que se va a ipulsar hacia atrás al jugador al ser golpeado por un objeto hostil
    [SerializeField] private float empujeZombie = 0.5f; // Fuerza con la que se va a impulsar el zombie cuando nos ataque
    #endregion

    #region methods
    public override void Damage(int DamagePoints)
    {
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
            pushing = true;
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
        _myPlayerMovementController = GetComponent<Player_MovementController>();
    }

    // Update is called once per frame
    override public void Update()
    {
        if (_currentLife <= 0)
        {
            // Para no poder moverse durante la animación de muerte
            AnimatorManager.Instance.PlayerisDead(_myAnimator);
            _myPlayerMovementController._movementSpeed = 0;
            _cont -= Time.deltaTime;
            if (_cont <= 0)
            {
                Die(); //GameManager.Instance.OnPlayerDies();
                GameManager.Instance.LoadGameOverMenu();
                _cont = 1.7f;
            }
        }
        _lifeBar.fillAmount = _currentLife / _maxLife;

        //Debug.Log(_currentLife);
    }
}