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

    #region references
    private Transform _mytransform;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision) //Cuando colisione el misil
    {
        Life_Component hitZombie = collision.GetComponent<Life_Component>();
        ColisionParedes hitWalls = collision.GetComponent<ColisionParedes>();
        if (hitZombie)
        {
            hitZombie.Damage(_damage);
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
