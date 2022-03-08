using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cadaver : MonoBehaviour
{
    private Input_Manager _myInputManager;
    [SerializeField]
    private GameObject _player;
    #region methods
    public void PalancaActivada()
    {
        _myInputManager._palancaActivated = true;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _myInputManager = _player.GetComponent<Input_Manager>();
    }

}
