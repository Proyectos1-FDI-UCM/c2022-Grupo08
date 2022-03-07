using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botiquin : MonoBehaviour
{
    #region references
    private Player_Life_Component _myPlayerLifeComponent;
    [SerializeField]
    private GameObject _player;
    #endregion
    #region parameters
    [SerializeField]
    private int _curacion = 20;
    #endregion 
    #region methods
    private void Elimina() //Elimina el botiquin
    {
        GameManager.Instance.EliminaBotiquin();
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myPlayerLifeComponent = _player.GetComponent<Player_Life_Component>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_myPlayerLifeComponent._currentLife > 0 && _myPlayerLifeComponent._currentLife < 100) 
        {
            if (Input.GetKey(KeyCode.E)) // Si se presiona la E, el jugador se cura y se elimina el botiquin
            {
                _myPlayerLifeComponent.Cura(_curacion);
                Elimina();
            }
        }
    }
}
