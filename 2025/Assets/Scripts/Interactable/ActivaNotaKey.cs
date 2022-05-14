using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaNotaKey : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _clip;
    #endregion
    #region methods
    public void ToShowNote() // M�todo que llama al GameManager para mostrar la nota 
    {
        GameManager.Instance.ActivateNoteKey();
        SoundManager.Instance.PlaySound(_clip);
        GameManager.Instance.NewMision("Busca la llave que te llevar� a la salida");
    }

    public void ToHideNote() // M�todo que llama al GameManager para esconder la nota
    {
        GameManager.Instance.DeactivateNoteKey();
        SoundManager.Instance.PlaySound(_clip);
    }

    #endregion
}
