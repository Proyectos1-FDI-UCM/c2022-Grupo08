using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Component : MonoBehaviour
{
    #region parameters
    public float _maxLife = 100.0f;
    public float _currentLife;
    [SerializeField] private  int _damage = 10;
    [SerializeField] protected float _cont = 1.7f;
    
    public bool _isDead = false;
    #endregion
    #region references
    [SerializeField] protected Animator _myAnimator;
    [SerializeField] private AudioClip _clip;
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
        SoundManager.Instance.PlaySound(_clip);
        
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
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (_currentLife <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _isDead = true;
            _cont -= Time.deltaTime;
            //Contador
            if (_cont <= 0) //GameManager.Instance.OnEnemyDies();
            {
                Die();
                _cont = 1.7f;
            }
        }

        //Animaci�n
        _myAnimator.SetBool("ZombieMuerto", _isDead);
    }
}