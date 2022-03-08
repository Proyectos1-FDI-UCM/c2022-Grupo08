using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    #region parameters
    private Vector3 rotationVector;
    [SerializeField]
    private int cargadorbalag;
    [SerializeField]
    private int cargadorbalasg;
    private int faltabalag;
    private int faltabalasg;
    [SerializeField]
    private float recargag;
    [SerializeField]
    private float recargasg;
    private float tiempocarga;
    private bool recargando;
    [SerializeField]
    private int totalbalasg;
    [SerializeField]
    private int totalbalassg;
    private bool tengoammog = true;
    private bool tengoammosg = true;
    #endregion

    #region properties
    [SerializeField]
    private GameObject pbala;
    [SerializeField]
    private GameObject gbala;
    [SerializeField]
    private GameObject sgbala;
    private bool holdingInteract = false; // Booleano que detecta si se ha presionado la E para interactuar mientras se est� en la zona de interacci�n
    #endregion

    #region references
    private Transform _mytransform;
    private Input_Manager _myInputManager;
    #endregion

    #region methods
    public void ShootBala(int tipobala, int dir)
    {
        if (dir == 1)
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

        if (tipobala == 1)
        {
            GameObject.Instantiate(pbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector));
        }

        else if (tipobala == 2)
        {
            if (tengoammog || (faltabalag > 0))
            {
                if (!recargando)
                {
                    GameObject.Instantiate(gbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector));
                    faltabalag -= 1;
                    UI_Manager.Instance.balagUI(faltabalag, totalbalasg);
                }
            }
        }
        else if (tipobala == 3)
        {
            if (tengoammosg || (faltabalasg > 0))
            {
                if (!recargando)
                {
                    GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector));
                    GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector + new Vector3(0, 0, 15)));
                    GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector + new Vector3(0, 0, -15)));
                    faltabalasg -= 1;
                    UI_Manager.Instance.balasgUI(faltabalasg, totalbalassg);
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision) // Si el player est� en la zona de interacci�n se puede pulsar la E
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
        if (holdingInteract) // Interactua con el objeto que est� en la zona de interacci�n
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
    private void OnTriggerExit2D(Collider2D collision) // Si el player se ha salido de la zona de interacci�n no se puede pulsar la E
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

    public void SumaBala(int tipobala, int cargadores)
    {
        if (tipobala == 0)
        {
            totalbalasg += cargadores * cargadorbalag;
            tengoammog = true;
            UI_Manager.Instance.balagUI(faltabalag, totalbalasg);
        }
        else if (tipobala == 1)
        {
            totalbalassg += cargadores * cargadorbalasg;
            tengoammosg = true;
            UI_Manager.Instance.balasgUI(faltabalasg, totalbalassg);
        }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
        _myInputManager = GetComponent<Input_Manager>();
        faltabalag = cargadorbalag;
        faltabalasg = cargadorbalasg;
    }

    // Update is called once per frame
    void Update()
    {
        if ((faltabalag == 0) && tengoammog)
        {
            recargando = true;
            tiempocarga += Time.deltaTime;
            if (tiempocarga >= recargag)
            {
                faltabalag = cargadorbalag;
                tiempocarga = 0;
                recargando = false;
                totalbalasg -= cargadorbalag;
                UI_Manager.Instance.balagUI(faltabalag, totalbalasg);
            }
        }

        if ((faltabalasg == 0)&&tengoammosg)
        {
            recargando = true;
            tiempocarga += Time.deltaTime;
            if (tiempocarga >= recargasg)
            {
                faltabalasg = cargadorbalasg;
                tiempocarga = 0;
                recargando = false;
                totalbalassg -= cargadorbalasg;
                UI_Manager.Instance.balasgUI(faltabalasg, totalbalassg);
            }
        }
        if (totalbalasg==0)
        {
            tengoammog = false;
        }
        if (totalbalassg == 0)
        {
            tengoammosg = false;
        }
    }
}
