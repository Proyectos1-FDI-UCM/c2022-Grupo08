using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{

    [SerializeField]
    List<Transform> wayPoints;

    float velocity = 2.0f;

    //Distancia minima a la que el jugador cambiará su objetivo al siguiente punto
    float changeDistance = 0.1f;

    //posicion
    int nextPosition = 0;

    private Transform _myTransform;

    // Start is called before the first frame update
    void Start()
    {
        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _myTransform.position = Vector3.MoveTowards(_myTransform.position, wayPoints[nextPosition].transform.position, velocity * Time.deltaTime);

        //SI la distancia es menor a la distancia de cambio, se pasa al siguiente waypoint
        if(Vector3.Distance(_myTransform.position,wayPoints[nextPosition].transform.position)<= changeDistance)
        {
            nextPosition++;

            if(nextPosition>= wayPoints.Count)
            {
                nextPosition = 0;
            }
        }
    }
}
