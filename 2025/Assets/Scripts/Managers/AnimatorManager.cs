using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    #region properties
    bool opening = false;
    bool elevator = false;
    bool _isZombieDead = false;
    bool _isPlayerDead = false;
    #endregion
    #region references
    static private AnimatorManager _instance;
    static public AnimatorManager Instance
    {
        get
        {
            return _instance;
        }
    }
    #endregion
    #region methods
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OpenDoor(Animator animator)
    {
        opening = true;
        animator.SetBool("abriendo", opening);
    }
    public void OpenElevator(Animator animator)
    {
        elevator = true;
        animator.SetBool("Elevator", elevator);
    }
    public void EnemyMovement(Animator animator, float positionx, float positiony, Transform player, Transform zombie, bool detection)
    {
        animator.SetFloat("Posx", positionx);
        animator.SetFloat("Posy", positiony);
        animator.SetFloat("Puntox", player.position.x - zombie.position.x);
        animator.SetFloat("Puntoy", player.position.y - zombie.position.y);
        animator.SetBool("Jugador", detection);
    }
    public void ZombieisDead(Animator animator)
    {
        _isZombieDead = true;
        animator.SetBool("ZombieMuerto", _isZombieDead);
    }
    public void PlayerisDead(Animator animator)
    {
        _isPlayerDead = true;
        animator.SetBool("isDead", _isPlayerDead);
    }
    #endregion
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
