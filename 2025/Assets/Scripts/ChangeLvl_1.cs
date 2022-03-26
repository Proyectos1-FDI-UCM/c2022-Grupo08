using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLvl_1 : MonoBehaviour
{
    
    #region methods
    private void OnTriggerStay2D(Collider2D collision)
    {
        Player_Life_Component hitPlayer = collision.GetComponent<Player_Life_Component>();

        if (hitPlayer)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
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
