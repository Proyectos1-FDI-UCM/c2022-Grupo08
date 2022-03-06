using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivaNota : MonoBehaviour
{    
    #region references
    private Input_Manager _myInputManager;
    #endregion
  

    
    // Start is called before the first frame update
    void Start()
    {
        _myInputManager = GetComponent<Input_Manager>();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
