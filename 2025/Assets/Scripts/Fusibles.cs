using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusibles : MonoBehaviour
{
    #region methods
    public void SumaFusible()
    {
        GameManager.Instance.CheckFusibles();
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
