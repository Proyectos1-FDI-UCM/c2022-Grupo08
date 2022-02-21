using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Barricada : MonoBehaviour
{
    [SerializeField]
    private Player_Life_Component _player_life_component;


    void Main()
    {
        _player_life_component = GetComponent<Player_Life_Component>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _player_life_component.Damage();
    }
}

