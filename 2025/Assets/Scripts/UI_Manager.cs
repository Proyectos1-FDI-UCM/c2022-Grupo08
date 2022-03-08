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
    #endregion
    #region methods
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
