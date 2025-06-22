using SO;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource _audioSource;

    [SerializeField] private AudioClipListSO menuList;
    [SerializeField] private AudioClipListSO levelList;
    void Start()
    {

        _audioSource = GetComponent<AudioSource>();
        if (Instance == null)
        {
            MusicManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        PlayMenuMusic();
    }


    public void PlayMenuMusic()
    {
        _audioSource.clip = menuList.TakeRandom();
        _audioSource.Play();
    }
    
    
    public void PlayLevelMusic()
    {
        _audioSource.clip = levelList.TakeRandom();
        _audioSource.Play();
    }

}
