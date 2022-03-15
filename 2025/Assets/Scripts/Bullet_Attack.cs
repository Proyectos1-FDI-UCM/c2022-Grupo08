using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Attack : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float velocidad = 1.0f;
    [SerializeField]
    private int daño = 1;
    [SerializeField]
    private float vida = 1.0f;
    private float timer;
    #endregion

    #region references
    private Transform _mytransform;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision) //Cuando colisione el misil
    {
        Life_Component hitZombie = collision.GetComponent<Life_Component>();
        ColisionParedes hitParedes = collision.GetComponent<ColisionParedes>();
        if (hitZombie)
        {
            hitZombie.Damage(daño);
            Destroy(gameObject);
        }

        if (hitParedes)
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
        transform.Translate(velocidad * Vector3.right * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer>=vida)
        {
            Destroy(gameObject);
        }
    }
}
