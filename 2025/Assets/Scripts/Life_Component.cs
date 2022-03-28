using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Component : MonoBehaviour
{
    #region parameters
    public int _maxLife = 100;
    public int _currentLife;
    [SerializeField] private int _damage = 10;
    [SerializeField] protected float _cont = 1.7f;
    [SerializeField] private float empujeZombie = 5.0f;
    #endregion
    #region references
    [SerializeField] protected Animator _myAnimator;
    private Rigidbody2D _myRigidBodyZombie;
    private Transform _myTransformZombie;
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
        _myRigidBodyZombie.AddForce(_myTransformZombie.position * -empujeZombie, ForceMode2D.Impulse);
        
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
        _myTransformZombie = transform;
        _myRigidBodyZombie = GetComponent<Rigidbody2D>();
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