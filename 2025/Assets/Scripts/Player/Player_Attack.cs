using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    #region parameters
    private Vector3 rotationVector;
    [SerializeField] private int cargadorbalag = 10;
    [SerializeField] private int cargadorbalasg = 2;
    [SerializeField] private int faltabalag;
    [SerializeField] private int faltabalasg;
    [SerializeField] private float recargag = 1;
    [SerializeField] private float recargasg = 2;
    private float tiempocarga;
    [SerializeField]
    private bool recargando;
    [SerializeField]
    private int totalbalasg;
    [SerializeField]
    private int totalbalassg;
    [SerializeField]

    private bool tengoammog = false;
    [SerializeField]
    private bool tengoammosg = false;
    #endregion

    #region properties
    [SerializeField] private GameObject pbala;
    [SerializeField] private GameObject gbala;
    [SerializeField] private GameObject sgbala;
    #endregion

    #region references
    private Transform _mytransform;
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
                    GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector + new Vector3(0, 0, 10)));
                    GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector + new Vector3(0, 0, 20)));
                    GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector + new Vector3(0, 0, -10)));
                    GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.Euler(rotationVector + new Vector3(0, 0, -20)));
                    faltabalasg -= 1;
                    UI_Manager.Instance.balasgUI(faltabalasg, totalbalassg);
                }
            }
        }
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
        faltabalag = 9; //lore interno
        faltabalasg = 0;
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
                recargando = false;
                faltabalag = cargadorbalag;
                tiempocarga = 0;
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
