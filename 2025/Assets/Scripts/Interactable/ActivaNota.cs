using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivaNota : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _clip;
    #endregion
    #region methods
    public void ToShowNote() // M�todo que llama al GameManager para mostrar la nota 
    {
        GameManager.Instance.ActivateNoteRoom();
        SoundManager.Instance.PlaySound(_clip);      
    }

    public void ToHideNote() // M�todo que llama al GameManager para esconder la nota
    {         
        GameManager.Instance.DeactivateNoteRoom();
        SoundManager.Instance.PlaySound(_clip);
    }

    #endregion
}
