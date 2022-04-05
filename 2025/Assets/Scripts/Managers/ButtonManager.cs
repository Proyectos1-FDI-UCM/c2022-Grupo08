using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    #region methods
    public void MuteButton(AudioSource sound)
    {
        UI_Manager.Instance.MuteMusicButton(sound);
    }
    public void MuteSFXButton(AudioSource effect)
    {
        UI_Manager.Instance.MuteSFXButton(effect);
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
    public void ReplayButton()
    {
        UI_Manager.Instance.ReplayButton();
    }
    public void StartGame()
    {
        UI_Manager.Instance.StartGame();
    }

    public void BackButtonNoteRoom()
    {
        UI_Manager.Instance.BackButtonNoteRoomCall();
    }
    public void BackButtonNoteElevator()
    {
        UI_Manager.Instance.BackButtonNoteElevatorCall();
    }
    public void BackButtonNoteKey()
    {
        UI_Manager.Instance.BackButtonNoteKeyCall();
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
