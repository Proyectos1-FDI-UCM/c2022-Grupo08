using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityActivated : MonoBehaviour
{
    #region methods
    public void InterruptorActivated()
    {
        LightManager.Instance.LightsGlobalActivated();
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