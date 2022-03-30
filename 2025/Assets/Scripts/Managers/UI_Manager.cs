using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    #region references
    static private UI_Manager _instance; 
    static public UI_Manager Instance 
    {
        get
        {
            return _instance; 
        }
    }
    #endregion
    #region parameters
    public Image lifeBar;
    public Text balasg;
    public Text balassg;
    public Text palancaaviso;
    public Text _mision;
    private float temporizadorpalanca;
    private bool gogo=false;
    
    public float maxlife;
    public float currentlife;
    [SerializeField] private GameObject _customizationMenu;
    [SerializeField] private GameObject _controlsMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _pauseMenu;
    #endregion
    #region methods
    public void Awake()
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
    public void palanca()
    {
        palancaaviso.text = "Pulse Espacio para golpear con la palanca";
        gogo = true;
    }
    public void balagUI(int bala,int cargador)
    {
        balasg.text = "" + bala + "/" + cargador;
    }
    public void balasgUI(int bala,int cargador)
    {
        balassg.text= "" + bala + "/" + cargador;
    }

   

    public void Mision(string write)
    {
        _mision.text = write;
    }

    //public void CustomizationMenu(bool enabled)
    //{
    //    _customizationMenu.SetActive(enabled);
    //    _mainMenu.SetActive(!enabled);
    //}

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }


    public void ControlsMenu(bool enabled)
    {
        _controlsMenu.SetActive(enabled);
    }
    public void PauseMenu(bool enabled)
    {
        _pauseMenu.SetActive(enabled);
        if (!enabled)
        {
            GameManager.Instance.IsGamePaused = false;
        }
    }
    public void WinMenu()
    {       
        _winMenu.SetActive(true); // Activa el menú de victoria
    }

    public void GameOverMenu()
    {
        _loseMenu.SetActive(true);
    }
    public void MuteButton()
    {
        SoundManager.Instance.MuteVolume();
    }

    public void ReplayButton()
    {
        GameManager.Instance.Replay();
    }
    public void Quit()
    {
        GameManager.Instance.QuitGame();
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        balasg.text = "";
        balassg.text = "";
        palancaaviso.text = "";
        _mision.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(gogo)
        {
            temporizadorpalanca += Time.deltaTime;
            if (temporizadorpalanca >= 5)
            {
                palancaaviso.text = "";
                temporizadorpalanca = 0;
                gogo = false;
            }
        }
    }
}
