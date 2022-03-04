using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDetection : MonoBehaviour
{
    #region references
   
    #endregion

    #region methods
    public void Interact()
    {
        GameManager.Instance.InteractableObjectDone(this); // Llamo al GameManager para eliminar de escena el objeto con el que ya he interactuado
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
