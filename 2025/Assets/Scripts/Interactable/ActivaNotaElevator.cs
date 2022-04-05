using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaNotaElevator : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _clip;
    #endregion
    #region methods
    public void ToShowNote() // M�todo que llama al GameManager para mostrar la nota 
    {
        GameManager.Instance.ActivateNoteElevator();
        SoundManager.Instance.PlaySound(_clip);
        if (LightManager.Instance._currentFusibles < 1)
        {
            GameManager.Instance.NewMision("Parece que tienes que usar el ascensor... Recoge fusibles 0/3");
        }
    }

    public void ToHideNote() // M�todo que llama al GameManager para esconder la nota
    {
        GameManager.Instance.DeactivateNoteElevator();
        SoundManager.Instance.PlaySound(_clip);
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
