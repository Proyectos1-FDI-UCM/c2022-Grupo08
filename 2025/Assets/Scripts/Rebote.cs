using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebote : MonoBehaviour
{

    float posX, posY;




    public void guardarPos()
    {
        posX = transform.position.x;
        posY = transform.position.y;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        guardarPos();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damage_Barricada>())
        {
            transform.position = new Vector2(posX, posY);


        }

    }
}
