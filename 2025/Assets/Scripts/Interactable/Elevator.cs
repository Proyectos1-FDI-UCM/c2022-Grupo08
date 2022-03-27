using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private GameObject _changeLevel;
    #region methods
    public void IsOpenElevator()
    {
        //GameManager.Instance.ElectrictyActivated();
    }

    public void OpenElevator()
    {
        //GameManager.Instance.OpenElevatorDoor();
        //Hacer animacion
        _changeLevel.SetActive(true);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         IsOpenElevator();
    }
}
