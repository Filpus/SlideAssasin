using UnityEngine;

namespace SO
{
    [CreateAssetMenu]
    public class AudioClipListSO : ScriptableObject
    {
        public AudioClip[] AudioClips;

        public AudioClip TakeRandom()
        {
            // Sprawdzenie, czy tablica istnieje i zawiera elementy
            if (AudioClips == null || AudioClips.Length == 0)
            {
                Debug.LogWarning("AudioClips jest null lub pusta."); 
                return null;
            }

            // Losowanie indeksu z przedziału [0, AudioClips.Length)
            int randomIndex = Random.Range(0, AudioClips.Length); 
            return AudioClips[randomIndex];
        }
    }
}