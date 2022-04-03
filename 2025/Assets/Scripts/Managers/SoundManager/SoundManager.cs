using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
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
    public void MuteVolume()
    {
        Debug.Log("Hola");
        //Poner Volumen a 0
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
