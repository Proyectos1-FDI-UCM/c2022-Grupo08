using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingDoor : MonoBehaviour
{
    public void ToExitHospital()
    {
        GameManager.Instance.OpenParkingDoor();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
