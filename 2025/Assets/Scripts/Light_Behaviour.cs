using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Behaviour : MonoBehaviour
{
    #region parameters

    [SerializeField]
    private GameObject _puerta;

    #endregion

    #region properties
    [SerializeField]
    private bool state = true;
    #endregion

    #region methods

    public void CambioEstadoLuces()
    {
        state = !state;

        this.gameObject.SetActive(state);

        //Debug.Log("Holi");

        if (GameManager.Instance._electricidadActiva)
        {
            CancelInvoke("CambioEstadoLuces");
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("CambioEstadoLuces", 0.75f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
