using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoom : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _roomToActivate;

    [SerializeField]
    private Animator _myAnimator;

    [SerializeField] private float _cont = 1.7f;
    bool opening = false;
    

    
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Life_Component hitPlayer = collision.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            NuevaHab();


            //Animacion abrir puerta
            opening = true;
            _myAnimator.SetBool("abriendo", opening);


        }
    }
    private void NuevaHab()
    {
        GameManager.Instance.ActivarHabitacion(_roomToActivate, this);
        UI_Manager.Instance.Mision("Nueva misi�n:");


    }

    

    
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(opening);
        //if ()
        //{
        //    _cont -= Time.deltaTime;
        //    Debug.Log(_cont);
        //    //Contador
        //    if (_cont <= 0) //GameManager.Instance.OnEnemyDies();
        //    {
                
        //        open = true;
        //        _myAnimator.SetBool("abierto", open);
                
        //    }
        //}

        
        



    }
}
