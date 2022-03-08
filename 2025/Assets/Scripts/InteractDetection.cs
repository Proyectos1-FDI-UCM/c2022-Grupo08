using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDetection : MonoBehaviour
{

    private bool _isNotaActivada = false;
    #region references
    private ActivaNota _myActivaNota;
    private Municion _myMunicion;
    private Botiquin _myBotiquin;
    private Fusibles _myFusibles;
    private Cadaver _myCadaver;
    private Cadaver2 _myCadaver2;
    private Cadaver3 _myCadaver3;
    #endregion

    #region methods
    public void Interact(int indice)
    {
        if (indice == 1) // Municion
        {
            _myMunicion.DaAmmo();// LLamar al metodo del script Municion para que haga lo que tenga que hacer con un _myMunicion.
        }
        else if (indice == 2) // Fusibles
        {
            _myFusibles.SumaFusible(); // LLamar al metodo del script Fusibles para que haga lo que tenga que hacer con un _myFusibles.
        }
        else if (indice == 3) // Botiquin
        {
            _myBotiquin.AplicaCura(); // LLamar al metodo del script Botiquin para que haga lo que tenga que hacer con un _myBotiquin.
        }
        else if (indice == 4) // ActivaNota
        {
            _myActivaNota.ToShowNote(); // LLama al metodo del script ActivaNota para que muestre la nota en pantalla                
        }
        else if (indice == 5) // Cadaver
        {
            _myCadaver.PalancaActivada(); // LLama al metodo del script Cadaver               
        }
        else if (indice == 6) // Cadaver2
        {
            _myCadaver2.PistolaActivada(); // LLama al metodo del script Cadaver2               
        }
        else if (indice == 7) // Cadaver3
        {
            _myCadaver3.EscopetaActivada(); // LLama al metodo del script Cadaver3              
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
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
