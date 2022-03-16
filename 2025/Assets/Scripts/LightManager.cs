using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    #region references
    static private LightManager _instance; // Unique LightManager instance (Singleton Pattern).
    static public LightManager Instance // Public accesor for LightManager instance.
    {
        get
        {
            return _instance; // Para poder instanciar el LightManager y llamarlo desde cualquier script
        }
    }
    public void ActivarHabitacion(GameObject Room, NewRoom triggerToDestroy)
    {
        //if (Time.deltaTime % 5 == 0)
        //{
            Room.SetActive(true);
            Destroy(triggerToDestroy);
        //}
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
