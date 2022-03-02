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
    #endregion

    #region references
    private Transform _mytransform;
    #endregion

    #region methods
    public void ShootBala(int tipobala)
    {
        if (tipobala==1)
        {
            GameObject.Instantiate(pbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (tipobala == 2)
        {
            GameObject.Instantiate(gbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
        else if (tipobala == 3)
        {
            GameObject.Instantiate(sgbala, _mytransform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _mytransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
