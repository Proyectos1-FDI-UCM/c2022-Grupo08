using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoom : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _targetToActivate;
    [HideInInspector]
    public bool isPlayerInNextRoom = false;
    [SerializeField]
    private GameObject _LightObject;
    private LightManager _myLightManager;
    #endregion

    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Life_Component hitPlayer = collision.GetComponent<Player_Life_Component>();
        if (hitPlayer)
        {
            NuevaHab();
            isPlayerInNextRoom = true;
        }
    }
    private void NuevaHab()
    {
        _myLightManager.ActivarHabitacion(_targetToActivate, this);
    }
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        _myLightManager = _LightObject.GetComponent<LightManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
