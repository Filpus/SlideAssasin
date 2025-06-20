using System;
using SO;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAudio: MonoBehaviour
    {

        [SerializeField] private AudioClipListSO PlayerAttackSound;
        [SerializeField] private AudioClipListSO PlayerDeathSound;
        [SerializeField] private AudioClipListSO PlayerDashSound;
        private AudioSource _audioSource;


        private void Awake()
        {
            _audioSource = this.GetComponent<AudioSource>();
        }
        public void PlayDash()
        {
            if (PlayerDashSound == null)
            {
                Debug.LogWarning("Brak klipów dash w AudioClipListSO"); 
                return;
            }

            AudioClip clip = PlayerDashSound.TakeRandom();
            _audioSource.PlayOneShot(clip);
        }

        public void PlayDeath()
        {
            if (PlayerDeathSound == null)
            {
                Debug.LogWarning("Brak klipów śmierci w AudioClipListSO"); 
                return;
            }

            AudioClip clip = PlayerDeathSound.TakeRandom();
            _audioSource.PlayOneShot(clip);
        }

        public void PlayAttack()
        {
            if (PlayerAttackSound == null )
            {
                Debug.LogWarning("Brak klipów ataku w AudioClipListSO"); 
                return;
            }

            AudioClip clip = PlayerAttackSound.TakeRandom();
            _audioSource.PlayOneShot(clip);
        }
    }
}