using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoom : MonoBehaviour
{
    #region references
    [SerializeField]
    private GameObject _roomToActivate;
    [SerializeField]
    private GameObject _lightsToActivate;
    [HideInInspector]
    public bool isPlayerInNextRoom = false;
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
        GameManager.Instance.ActivarHabitacion(_roomToActivate, _lightsToActivate, this);
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
