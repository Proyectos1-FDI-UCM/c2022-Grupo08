using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityActivated : MonoBehaviour
{
    #region methods
    public void InterruptorActivated()
    {
        GameManager.Instance.UnlockExit();
        LightManager.Instance.LightsGlobalActivated();
    }
    #endregion
}
