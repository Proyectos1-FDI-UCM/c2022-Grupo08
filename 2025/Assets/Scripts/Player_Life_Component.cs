using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life_Component : Life_Component
{
    /*private Transform _myTransform;

    float posXplayer, posYplayer;
    */
    #region methods
    public override void Damage(int DamagePoints)
    {
        base.Damage(DamagePoints);
    }
    #endregion

    // Start is called before the first frame upda

    // Update is called once per frame
    override public void Start()
    {
        base.Start();
    }

    /*private void guardarPosPlayer()
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
