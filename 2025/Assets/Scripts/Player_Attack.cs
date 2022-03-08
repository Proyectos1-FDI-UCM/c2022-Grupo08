using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    #region properties
    [SerializeField]
    private GameObject pbala;
    [SerializeField]
    private GameObject gbala;
    [SerializeField]
    private GameObject sgbala;
    private bool holdingInteract = false; // Booleano que detecta si se ha presionado la E para interactuar mientras se está en la zona de interacción
    private Vector3 rotationVector;
    #endregion

    #region references
    private Transform _mytransform;
    private Input_Manager _myInputManager;
    #endregion

    #region methods
    public void ShootBala(int tipobala, int dir)
    {
        if(dir==1)
        {
            rotationVector = new Vector3(0, 0, 90);
        }
        else if (dir == 2)
        {
            rotationVector = new Vector3(0, 0, -90);
        }
        else if (dir == 3)
        {
            rotationVector = new Vector3(0, 0, 180);
        }
        else if (dir == 4)
        {
            rotationVector = new Vector3(0, 0, 0);
        }

        if (tipobala==1)
        {
            GameObject.Instantiate(pbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector));
        }
        else if (tipobala == 2)
        {
            GameObject.Instantiate(gbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector));
        }
        else if (tipobala == 3)
        {
            GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector));
        }
    }
    private void OnTriggerStay2D(Collider2D collision) // Si el player está en la zona de interacción se puede pulsar la E
    {
        InteractDetection hitInteractableObject = collision.GetComponent<InteractDetection>();
        Fusibles hitFusible = collision.GetComponent<Fusibles>();
        ActivaNota hitNota = collision.GetComponent<ActivaNota>();
        Botiquin hitBotiquin = collision.GetComponent<Botiquin>();
        Municion hitMunicion = collision.GetComponent<Municion>();
        Cadaver hitCadaver = collision.GetComponent<Cadaver>();
        if (hitInteractableObject)
        {
            _myInputManager.InDetectionZone = true;
        }
        if (holdingInteract) // Interactua con el objeto que está en la zona de interacción
        {
            if (hitMunicion)
            {
                hitInteractableObject.Interact(1);
                ToCallInteraction();
            }
            else if (hitFusible)
            {
                hitInteractableObject.Interact(2);
                ToCallInteraction();
            }
            else if (hitBotiquin)
            {
                hitInteractableObject.Interact(3);
                ToCallInteraction();
            }
            else if (hitNota)
            {
                hitInteractableObject.Interact(4);
                ToCallInteraction();
            }
            else if (hitCadaver)
            {
                hitInteractableObject.Interact(5);
                ToCallInteraction();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // Si el player se ha salido de la zona de interacción no se puede pulsar la E
    {
        InteractDetection hitInteractableObject = collision.GetComponent<InteractDetection>();
        if (hitInteractableObject)
        {
            _myInputManager.InDetectionZone = false;
        }
    }

    public void ToCallInteraction() // Revierte el valor del booleano
    {
        holdingInteract = !holdingInteract;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
        _myInputManager = GetComponent<Input_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
