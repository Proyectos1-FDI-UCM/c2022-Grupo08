using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : MonoBehaviour
{

    int curretLife = 100;

    float posXplayer, posYplayer;



    private Transform _myTransform;

    // Start is called before the first frame update
     void Start()
     {
        _myTransform = transform;

     }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int damage)
    {
        curretLife -= damage;
    }

    private void guardarPosPlayer()
    {
        posXplayer = _myTransform.position.x;
        posYplayer = _myTransform.position.y;


    }

    public void Rebote( float posXenemy, float posYenemy)
    {
        if (posXplayer < posXenemy)
        {
            _myTransform.position = new Vector2(posXplayer - 1, posYplayer);
        }
        else if (posXplayer > posXenemy)
        {
            _myTransform.position = new Vector2(posXplayer + 1, posYplayer);
        }
        else if (posYplayer < posYenemy)
        {
            _myTransform.position = new Vector2(posXplayer , posYplayer-1);
        }
        else if (posYplayer > posYenemy)
        {
            _myTransform.position = new Vector2(posXplayer , posYplayer+1);
        }

    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damage>())
        {

            if (posXplayer < )
                _myTransform.position = new Vector2(posXplayer, posYplayer);


        }

    }*/
}
