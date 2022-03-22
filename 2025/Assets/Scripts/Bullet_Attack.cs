using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Attack : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _velocity = 1.0f;
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private float _life = 1.0f;
    private float _timer;
    #endregion

    #region properties
    private float empuje = 5f; //Fuerza con la que se va a ipulsar hacia atrás al zombie
    #endregion
    #region references
    private Transform _mytransform;
    private Rigidbody2D _myRigidBody;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision) //Cuando colisione el misil
    {
        Enemy_Behaviour hitZombie = collision.GetComponent<Enemy_Behaviour>();
        ColisionParedes hitWalls = collision.GetComponent<ColisionParedes>();
        Life_Component Life = collision.GetComponent<Life_Component>();
        if (hitZombie)
        {
            Debug.Log("CCC");
            var heading = hitZombie.transform.position - _mytransform.position; //Direccion de empuje    
            _myRigidBody.AddForce(heading * -empuje, ForceMode2D.Impulse);
            Life.Damage(_damage);
            Destroy(gameObject);
        }

        if (hitWalls)
        {
            Destroy(gameObject);
        }
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_velocity * Vector3.right * Time.deltaTime);
        _timer += Time.deltaTime;

        if (_timer >= _life)
        {
            Destroy(gameObject);
        }
    }
}
