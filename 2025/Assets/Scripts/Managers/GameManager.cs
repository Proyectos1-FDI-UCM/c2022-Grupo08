using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region parameters
    //[SerializeField]
    //private bool state = true;

    public bool boy = false;
    public bool girl = false;
    #endregion
    #region properties

    public bool _electricidadActiva = false;

    [SerializeField]
    private int _maxFusibles = 3;
    private int _currentFusibles = 0;

    //[SerializeField]
    //private GameObject _luces;
    [SerializeField]
    private GameObject _puerta;
    [SerializeField]
    private GameObject _nota;
    [SerializeField]
    private GameObject _botiquin;
    [SerializeField]
    private GameObject _boy;
    [SerializeField]
    private GameObject _girl;
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

    public void CheckFusibles() // Actualiza el numero de fusibles activos y los compara con el numero maximo posible para activar el panel electrico en su momento
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
    public void ActivarHabitacion(GameObject room, NewRoom triggerToDestroy)
    {
        room.SetActive(true);
        Destroy(triggerToDestroy);
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }

    
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boy)
        {
            _boy.SetActive(true);
        }
        else if (girl)
        {
            _girl.SetActive(true);
        }
    }
}
