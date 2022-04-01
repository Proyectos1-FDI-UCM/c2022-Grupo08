using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    bool elevator = false;

    #region references
    [SerializeField] private GameObject _changeLevel;
    [SerializeField] private Animator _myAnimator;
    [SerializeField] private AudioClip _clip;
    //[SerializeField] private GameObject _elevator;
    #endregion
    #region methods   
    public void OpenElevator()
    {
        //GameManager.Instance.OpenElevatorDoor();
        elevator = true;
        _myAnimator.SetBool("Elevator", elevator);
        _changeLevel.SetActive(true);
        this.gameObject.SetActive(false);
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
         
    }
}
