using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivaNota : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _clip;
    [SerializeField] private GameObject _player;
    private Input_Manager _myInputManager;
    #endregion
    #region methods
    public void ToShowNote() // Método que llama al GameManager para mostrar la nota 
    {
        _myInputManager._isNoteActivated = true;
        GameManager.Instance.ActivateNoteRoom();
        SoundManager.Instance.PlaySound(_clip);      
    }

    public void ToHideNote() // Método que llama al GameManager para esconder la nota
    {         
        GameManager.Instance.DeactivateNoteRoom();
        SoundManager.Instance.PlaySound(_clip);
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _myInputManager = _player.GetComponent<Input_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
