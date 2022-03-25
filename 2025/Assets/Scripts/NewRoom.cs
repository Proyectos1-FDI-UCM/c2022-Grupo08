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

    [SerializeField] private AudioClip _clip;
    
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Life_Component hitPlayer = collision.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            NuevaHab();
            //SoundManager
            SoundManager.Instance.PlaySound(_clip);

            //Animacion abrir puerta
            opening = true;
            _myAnimator.SetBool("abriendo", opening);
            

        }
    }
    private void NuevaHab()
    {
        GameManager.Instance.ActivarHabitacion(_roomToActivate, this);
        UI_Manager.Instance.Mision("Nueva misión:");


    }

    

    
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        
        



    }
}
