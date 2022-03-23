using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Component : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int _maxLife = 100;
    public int _currentLife;
    [SerializeField]
    private int _damage = 10;
    [SerializeField]
    protected float _cont = 1.7f;
    [SerializeField]
    private float empuje = 5.0f;
    #endregion
    #region references
    [SerializeField]
    protected Animator _myAnimator;
    private Rigidbody2D _myRigidBody;
    private Transform _myTransform;
    #endregion
    #region methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Life_Component hitPlayer = collision.gameObject.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            hitPlayer.Damage(_damage);
        }
    }

    public virtual void Damage(int damagePoint)
    {
        _currentLife -= damagePoint;
        _myRigidBody.AddForce(_myTransform.position * -empuje, ForceMode2D.Impulse);
        if (gameObject.GetComponent<Player_Life_Component>())
        {
            GameManager.Instance.GetDamage();
        }
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
    #endregion

    // Start is called before the first frame update
    public virtual void Start()
    {
        _currentLife = _maxLife;
        _myTransform = transform;
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (_currentLife <= 0)
        {
            _cont -= Time.deltaTime;

            //Contador
            if (_cont <= 0) //GameManager.Instance.OnEnemyDies();
            {
                Die();
                _cont = 1.7f;
            }
        }

        //Animación
        _myAnimator.SetInteger("Vida", _currentLife);
    }
}