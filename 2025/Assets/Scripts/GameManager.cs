using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region properties

    bool _electricidadActiva = false;

    [SerializeField]
    private int _maxFusibles = 3;
    private int _currentFusibles = 0;

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

    public void CheckFusibles()
    {
        _currentFusibles++;

        if(_currentFusibles >= _maxFusibles)
        {
            _electricidadActiva = true;
        }
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
