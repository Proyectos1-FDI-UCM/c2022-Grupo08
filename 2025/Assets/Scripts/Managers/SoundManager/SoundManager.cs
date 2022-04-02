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
    public void MuteMusic(bool music)
    {
        if (music)
        {
            _musicSource.mute = false;
        }
        else
        {
            _musicSource.mute = true;
        }
    }
    public void MuteSFX(bool effects)
    {
        if (effects)
        {
            _effectSource.mute = false;
            zombieMuted = false;
        }
        else
        {
            zombieMuted = true;
            _effectSource.mute = true;
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
