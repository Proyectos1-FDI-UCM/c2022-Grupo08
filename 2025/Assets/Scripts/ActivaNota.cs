using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivaNota : MonoBehaviour
{    
    #region methods
    public void ToShowNote() // Método que llama al GameManager para mostrar la nota 
    {
        GameManager.Instance.ActivateNote();
    }

    public void ToHideNote() // Método que llama al GameManager para esconder la nota
    {         
        GameManager.Instance.DeactivateNote();       
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) // Input especial para esconder la nota
        {
            ToHideNote();
        }
    }
}
