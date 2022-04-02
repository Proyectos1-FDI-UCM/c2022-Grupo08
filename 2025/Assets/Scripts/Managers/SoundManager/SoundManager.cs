using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region parameters
    public bool zombieMuted = false;
    #endregion
    #region references
    [SerializeField] private AudioSource _effectSource, _musicSource;
    static private SoundManager _instance;
    static public SoundManager Instance
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
    public void MuteMusic(AudioSource music)
    {
        if (music.mute)
        {
            music.mute = false;
        }
        else
        {
            music.mute = true;
        }
    }

    public void MuteSFX(AudioSource effects)
    {
        if (effects.mute)
        {
            effects.mute = false;
            zombieMuted = true;
            //_slowZombie = false;
            //_fastZombie.mute = false;
            //_strongZombie.mute = false;
        }
        else
        {
            zombieMuted = false;
            effects.mute = true;
            //_slowZombie.mute = true;
            //_fastZombie.mute = true;
            //_strongZombie.mute = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
