using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region parameters
    public bool boy;
    #endregion

    #region properties
    public bool IsGamePaused = false;
    public float _currentLife = 100;
    float _maxLife = 100;
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
    [SerializeField] private GameObject _nota;
    [SerializeField] private GameObject _botiquin;
    [SerializeField] private GameObject _elevatorClosed;
    [SerializeField] private GameObject _elevatorOpened;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _parkingDoor;
    [SerializeField] private GameObject _exitHospital;
    [SerializeField] private GameObject _boy;
    [SerializeField] private GameObject _girl;
    [SerializeField] private Transform _spawn;
    private GameObject saved;
    [SerializeField] private List<InteractDetection> _listInteractableObjects;
    private UI_Manager _UIManager;
    #endregion
    #region methods
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }        
    }
    public void InteractableObjectDone(InteractDetection _myInteractDetection) // Gestiona la interaccion con objetos interactuables
    {
        _listInteractableObjects.Remove(_myInteractDetection); // Elimino al objecto con el que interactuado de la lista
        Destroy(_myInteractDetection.gameObject); // Destruye al objeto interactuado de escena
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

    public void GetKey()
    {       
        _parkingDoor.SetActive(true);
    }

    public void OpenParkingDoor()
    {
        _exitHospital.GetComponent<BoxCollider2D>().isTrigger = true;
    }

   

    /*public void OnPlayerDies()
    {
        //_boy.SetActive(false);
        //_girl.SetActive(false);
        SceneManager.LoadScene(3, LoadSceneMode.Single);
        
    }*/
    public void PauseGame()
    {
        IsGamePaused = true;
        UI_Manager.Instance.PauseMenu(true);   
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
    //public void StartGameBoy()
    //{
    //    boy = true;
    //    SceneManager.LoadScene(1);
    //    _boy.transform.position = _spawn.position;
    //    Destroy(_girl);
    //    _boy.SetActive(true);
    //}
    //public void StartGameGirl()
    //{
    //    boy = false;
    //    SceneManager.LoadScene(1);
    //    _girl.transform.position = _spawn.position;
    //    Destroy(_boy);
    //    _girl.SetActive(true);
    //}
   
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Replay() 
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void LoadGameOverMenu()
    {
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }

    public void OnLevelWasLoaded(int level)
    {
        SceneManager.GetActiveScene(); 

        if(level == 3)
        {
            UI_Manager.Instance.WinMenu(); // Llamada para que salga el menú de victoria
        }
        if (level == 4)
        {
            UI_Manager.Instance.GameOverMenu();
        }
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        /*if (boy)
        {
            _boy.transform.position = _spawn.position;
            Destroy(_girl);
            _boy.SetActive(true);
        }
        else
        {
            _girl.transform.position = _spawn.position;
            Destroy(_boy);
            _girl.SetActive(true);
        }*/
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
