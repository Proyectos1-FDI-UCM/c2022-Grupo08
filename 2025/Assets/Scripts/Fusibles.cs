using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusibles : MonoBehaviour
{
    #region references
    private Input_Manager _myInputManager;
    private GameManager _myGameManager;
    #endregion
    #region methods

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player_Life_Component _myPlayerLifeComponent = collision.gameObject.GetComponent<Player_Life_Component>();

        if(_myPlayerLifeComponent && _myInputManager.InDetectionZone == true)
        {
            _myGameManager.CheckFusibles();
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myInputManager = GetComponent<Input_Manager>();
        _myGameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
