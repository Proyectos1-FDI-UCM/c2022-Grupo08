using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    #region references
    [SerializeField] private Animator _transition;
    [SerializeField] int level;
    #endregion

    #region methods
    public void Awake()
    {
        _transition = GetComponent<Animator>();
    }
    public void FadeOut()
    {
        _transition.SetTrigger("Fadeout");
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
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
