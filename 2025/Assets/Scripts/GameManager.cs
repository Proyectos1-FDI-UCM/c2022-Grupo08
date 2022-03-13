using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private bool state = true;
    #endregion
    #region properties

    bool _electricidadActiva = false;

    [SerializeField]
    private int _maxFusibles = 3;
    private int _currentFusibles = 0;

    [SerializeField]
    private GameObject _luces;
    [SerializeField]
    private GameObject _puerta;
    [SerializeField]
    private GameObject _nota;
    [SerializeField]
    private GameObject _botiquin;
    #endregion
    #region references
    static private GameManager _instance; // Unique GameManager instance (Singleton Pattern).
    static public GameManager Instance // Public accesor for GameManager instance.
    {
        get
        {
            return _instance; // Para poder instanciar el GameManager y llamarlo desde cualquier script
        }
    }
    [SerializeField]
    private List<InteractDetection> _listInteractableObjects; 
    #endregion

    #region methods
    private void Awake()
    {
        _instance = this;
    }
    public void InteractableObjectDone(InteractDetection _myInteractDetection) // Gestiona la interaccion con objetos interactuables
    {
        _listInteractableObjects.Remove(_myInteractDetection); // Elimino al objecto con el que interactuado de la lista
        Destroy(_myInteractDetection.gameObject); // Destruye al objeto interactuado de escena
    }

    public void CheckFusibles() //Actualiza el numero de fusibles activos y los compara con el numero maximo`posible para activar el panel electrico en su momento
    {
        _currentFusibles++;

        if(_currentFusibles >= _maxFusibles)
        {
            _electricidadActiva = true;

            Destroy(_puerta);
        }
    }
    public void ActivateNote() // Activa la nota
    {
        _nota.SetActive(true);
    }
    public void DeactivateNote() // Desactiva la nota 
    {
        _nota.SetActive(false);
    }
    public void EliminaBotiquin()
    {
        _botiquin.SetActive(false);
    }

    public void CambioEstadoLuces()
    {
        state = !state;
        
        _luces.SetActive(state);

        //Debug.Log("Holi");

        if (_electricidadActiva)
        {
            CancelInvoke("CambioEstadoLuces");
        }
    }

    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CambioEstadoLuces", 0.75f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
