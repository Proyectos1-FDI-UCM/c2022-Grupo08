using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    #region parameters
    [SerializeField]
    private float _lightDelay = 0.75f;
    #endregion

    #region properties
    private bool state = true;
    #endregion

    #region references
    [SerializeField]
    private List<Light_Behaviour> _lightList;
    #endregion

    #region references
    static private LightManager _instance; // Unique LightManager instance (Singleton Pattern).
    static public LightManager Instance // Public accesor for LightManager instance.
    {
        get
        {
            return _instance; // Para poder instanciar el LightManager y llamarlo desde cualquier script
        }
    }
    
    public void LightsActivated(Light_Behaviour lightsToActive)
    {
        _lightList.Add(lightsToActive);
    }
    private void CambioEstadoLuces()
    {
        state = !state;

        //this.gameObject.SetActive(state);
        foreach(Light_Behaviour _myLight in _lightList)
        {
            _myLight.gameObject.SetActive(state);
        }

        if (GameManager.Instance._electricidadActiva)
        {
            CancelInvoke("CambioEstadoLuces");
        }
    }

    private void Awake()
    {
        _instance = this;
        _lightList = new List<Light_Behaviour>();
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CambioEstadoLuces", _lightDelay, _lightDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
