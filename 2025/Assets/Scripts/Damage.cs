using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private Player_Life_Component _player_life_component;

    float posXenemy, posYenemy;

    private Transform _myTransform;

    void Main()
    {
        _player_life_component = GetComponent<Player_Life_Component>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void guardarPosEnemy()
    {
        posXenemy = _myTransform.position.x;
        posYenemy = _myTransform.position.y;


    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player_life_component.Damage(10);
        _player_life_component.Rebote(posXenemy, posYenemy);
    }
}

