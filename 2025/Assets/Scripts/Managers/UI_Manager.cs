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
    public Text pistolBullets;
    public Text shotgunBullets;
    public Text palancaaviso;
    public Text _mision;
    private float temporizadorpalanca;
    private bool gogo=false;
    
    public float maxlife;
    public float currentlife;
    [SerializeField] private GameObject _customizationMenu;
    [SerializeField] private GameObject _controlsMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _control1;
    [SerializeField] private GameObject _control2;
    [SerializeField] private GameObject _control3;
    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _muteButton;
    [SerializeField] private GameObject _unmuteButton;
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
    public void ShotgunActivate()
    {
        _control1.SetActive(true);
    }
    public void GunActivate()
    {
        _control2.SetActive(true);
    }
    public void LeverActivate()
    {
        //palancaaviso.text = "Pulse Espacio para golpear con la palanca";
        //gogo = true;
        _control3.SetActive(true);
    }
    public void balagUI(int bala,int cargador)
    {
        //pistolBullets.text = "" + bala + "/" + cargador;
    }
    public void balasgUI(int bala,int cargador)
    {
        //shotgunBullets.text= "" + bala + "/" + cargador;
    }

   

    public void Mision(string write)
    {
        //_mision.text = write;
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
    public void MuteButton(AudioSource sound)
    {
        SoundManager.Instance.MuteVolume(sound);
        if (sound.mute)
        {
            _unmuteButton.SetActive(true);
            _muteButton.SetActive(false);
        }
        else
        {
            _unmuteButton.SetActive(false);
            _muteButton.SetActive(true);
        }
    }

    public void ReplayButton()
    {
        GameManager.Instance.Replay();
    }
    public void Quit()
    {
        GameManager.Instance.QuitGame();
    }
    public void PauseReference()
    {
        _pauseMenu = GameObject.Find("PauseMenu");
        _pauseMenu.SetActive(false);
    }
    public void UnmuteButtonReference()
    {
        _unmuteButton = GameObject.Find("UnMuteButton");
        _unmuteButton.SetActive(false);
    }
    public void MuteButtonReference()
    {
        _muteButton = GameObject.Find("MuteButton");
    }
    public void ControlsReference()
    {
        _controlsMenu = GameObject.Find("ControlsMenu");
        _controlsMenu.SetActive(false);
    }
    public void Control1Reference()
    {
        _control1 = GameObject.Find("ControlEscopeta");
        _control1.SetActive(false);
    }
    public void Control2Reference()
    {
        _control2 = GameObject.Find("ControlPistola");
        _control2.SetActive(false);
    }
    public void Control3Reference()
    {
        _control3 = GameObject.Find("ControlPalanca");
        _control3.SetActive(false);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        pistolBullets = GameObject.Find("PistolBullets").GetComponent<Text>();
        shotgunBullets = GameObject.Find("ShotgunBullets").GetComponent<Text>();
        pistolBullets.text = "";
        shotgunBullets.text = "";
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
