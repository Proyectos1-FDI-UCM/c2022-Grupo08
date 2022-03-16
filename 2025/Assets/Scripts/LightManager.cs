using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    #region properties
    private float clockTick;
    #endregion

    #region references
    [SerializeField]
    private List<GameObject> _lightList;
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
    
    public void LightsActivated(GameObject lightsToActive)
    {
        lightsToActive.SetActive(true);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
        //Debug.Log(Time.time);
        //clockTick += Time.deltaTime;
    }
}
