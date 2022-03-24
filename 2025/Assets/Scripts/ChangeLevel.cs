using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    #region references
    [SerializeField]
    GameObject _elevator;
    [SerializeField]
    GameObject _parkingDoor;
    #endregion
    #region methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_Life_Component hitPlayer = collision.GetComponent<Player_Life_Component>();
        if (hitPlayer/* && _electrictyActivated*/)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
        if (hitPlayer)
        {     
            SceneManager.LoadScene(3, LoadSceneMode.Single);
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
