using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusibles : MonoBehaviour
{
    #region references
    [SerializeField] private AudioClip _clip;
    #endregion 
    #region methods
    public void SumaFusible()
    {
        LightManager.Instance.CheckFusibles();
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
