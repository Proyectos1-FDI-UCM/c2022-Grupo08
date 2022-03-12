using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text balasg;
    public Text balassg;
    public Text palancaaviso;
    private float temporizadorpalanca;
    private bool gogo=false;
    #endregion
    #region methods
    public void palanca()
    {
        palancaaviso.text = "Pulse 1 para golpear con la palanca";
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
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        balasg.text = "";
        balassg.text = "";
        palancaaviso.text = "";
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
