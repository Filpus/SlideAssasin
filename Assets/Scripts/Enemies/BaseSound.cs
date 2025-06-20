using UnityEngine;
using SO;

namespace Enemies
{
    public class BaseSound : MonoBehaviour
    {
        [SerializeField] private AudioClipListSO EnemySounds;
        private AudioSource _audioSource;


        private void Awake()
        {
            _audioSource = this.GetComponent<AudioSource>();
        }
        public void PlaySound()
        {
            if (EnemySounds == null)
            {
                return;
            }

            AudioClip clip = EnemySounds.TakeRandom();
            _audioSource.PlayOneShot(clip);
        }
    }
}