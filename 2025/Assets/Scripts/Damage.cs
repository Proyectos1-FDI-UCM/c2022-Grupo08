using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    /*
    /*[SerializeField]
    private GameObject _myPlayer;
    private Player_Life_Component _player_life_component;

    float posXenemy, posYenemy;

    private Transform _myTransform;

    public void guardarPosEnemy()
    {
        posXenemy = _myTransform.position.x;
        posYenemy = _myTransform.position.y;
        //Debug.Log(posXenemy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision");
        Player_Life_Component hitPlayer = collision.gameObject.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            _player_life_component.Damage(10);
            _player_life_component.Rebote(posXenemy, posYenemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        Player_Life_Component hitPlayer = collision.gameObject.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            Debug.Log("HitPlayer");
            hitPlayer.Damage(10);
            hitPlayer.Rebote(posXenemy, posYenemy);
        }
    }

    void Start()
    {
        _myTransform = transform;
        //_player_life_component = _myPlayer.GetComponent<Player_Life_Component>();
    }

    // Update is called once per frame
    void Update()
    {
        guardarPosEnemy();
    }*/
}

