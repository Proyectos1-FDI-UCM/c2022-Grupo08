using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    #region methods
    public void MuteButton(bool sound)
    {
        UI_Manager.Instance.MuteButton(sound);
    }

    public void Quit()
    {
        UI_Manager.Instance.Quit();
    }

    public void PauseMenu(bool enabled)
    {
        UI_Manager.Instance.PauseMenu(enabled);
    }

    public void ControlsMenu(bool enabled)
    {
        UI_Manager.Instance.ControlsMenu(enabled);
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
