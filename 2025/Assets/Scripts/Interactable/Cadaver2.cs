using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadaver2 : MonoBehaviour
{
    private Input_Manager _myInputManager;  
    //[SerializeField] private GameObject _player;
    #region methods

    public void PistolaActivada()
    {
        _myInputManager._pistolaActivada = true;        
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myInputManager = GameManager.Instance._player.GetComponent<Input_Manager>();      
    }
   
}
