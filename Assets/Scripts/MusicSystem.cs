using SO;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource _audioSource;

    [SerializeField] private AudioClipListSO playlist;
    void Start()
    {

        if (Instance == null)
        {
            MusicManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    
}
