using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaNotaShotgun : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _clip;
    #endregion
    #region methods
    public void ToShowNote() // M�todo que llama al GameManager para mostrar la nota 
    {
        GameManager.Instance.ActivateNoteShotgun();
        SoundManager.Instance.PlaySound(_clip);
        GameManager.Instance.NewMision("Parece que has conseguido la escopeta!! Sigue explorando...");
    }

    public void ToHideNote() // M�todo que llama al GameManager para esconder la nota
    {
        GameManager.Instance.DeactivateNoteShotgun();
        SoundManager.Instance.PlaySound(_clip);
    }

    #endregion
}
