using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Component : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int _maxLife = 100;
    [SerializeField]
    protected int _currentLife;
    [SerializeField]
    private int _damage = 10;
    [SerializeField]
    protected float _cont = 1.7f;
    #endregion
    #region methods

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Life_Component hitPlayer = collision.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            hitPlayer.Damage(_damage);
        }
    }
    */
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
    }

    protected void Die()
    {
        gameObject.SetActive(false);
    }
    #endregion
    #region references
    [SerializeField]
    protected Animator _myAnimator;
    #endregion 

    // Start is called before the first frame update
    public virtual void Start()
    {
        _currentLife = _maxLife;
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
