using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDetection : MonoBehaviour
{

    private bool _isNotaActivada = false;
    #region references 
    private Municion _myMunicion;
    private Fusibles _myFusibles;
    private Botiquin _myBotiquin;
    private ActivaNota _myActivaNota;
    private Cadaver _myCadaver;
    private Cadaver2 _myCadaver2;
    private Cadaver3 _myCadaver3;
    private Key _myKey;
    #endregion

    #region methods
    public void Interact(int indice)
    {
        switch(indice)
        {
            case 1: _myMunicion.DaAmmo(); break; // Municion
            case 2: _myFusibles.SumaFusible(); break; // Fusibles
            case 3: _myBotiquin.AplicaCura(); break; // Botiquin
            case 4: _myActivaNota.ToShowNote(); break; // ActivaNota
            case 5: _myCadaver.LeverActivated(); UI_Manager.Instance.palanca(); break; // Cadaver
            case 6: _myCadaver2.PistolaActivada(); break; // Cadaver2
            case 7: _myCadaver3.EscopetaActivada(); break; // Cadaver3
            case 8: _myKey.OpenParkingDoor(); break;// Llave
        }
        GameManager.Instance.InteractableObjectDone(this); // Llamo al GameManager para eliminar de escena el objeto con el que ya he interactuado
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myActivaNota = GetComponent<ActivaNota>();
        _myBotiquin = GetComponent<Botiquin>();
        _myFusibles = GetComponent<Fusibles>();
        _myMunicion = GetComponent<Municion>();
        _myCadaver = GetComponent<Cadaver>();
        _myCadaver2 = GetComponent<Cadaver2>();
        _myCadaver3 = GetComponent<Cadaver3>();
        _myKey = GetComponent<Key>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
