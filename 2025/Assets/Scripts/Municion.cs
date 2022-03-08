using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    #region references
    private Player_Attack _myPlayerAttack;
    [SerializeField]
    private GameObject _player;
    #endregion
    #region parameters
    [SerializeField]
    private int _sumabala = 20;
    #endregion 
    //establece que la cantidad de ammo que da la dicta el unity
    //en un solo script te vale todo
    //el attack ya tiene el suma bala específicado pero no hace falta la separación
    //que reciba 2 ints, el primero para el número de cargadores y el segundo la cantidad de balas en el cargador
    #region methods
    public void AplicaCura() //Elimina el botiquin
    {
        //if (_myPlayerLifeComponent._currentLife > 0 && _myPlayerLifeComponent._currentLife < 100)
        {
            //_myPlayerLifeComponent.Cura(_curacion);
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        //_myPlayerLifeComponent = _player.GetComponent<Player_Life_Component>();
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
