using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life_Component : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private int _maxLife = 100;
    [SerializeField]
    private int _currentLife;
    [SerializeField]
    private int _damage = 10;
    #endregion
    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Life_Component hitPlayer = collision.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            hitPlayer.Damage(_damage);
        }
    }

    public virtual void Damage(int damagePoint)
    {
        _currentLife -= damagePoint;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    #endregion

    // Start is called before the first frame update
    public virtual void Start()
    {
        _currentLife = _maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentLife <= 0)
        {
            Die();
        }
    }
}
