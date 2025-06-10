using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [Header("Komponenty")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _sfxSlider;

    [Header("Klucze PlayerPrefs")]
    [SerializeField] private string _musicVolumeKey = "MusicVolume";
    [SerializeField] private string _sfxVolumeKey = "SFXVolume";

    private float _minVolume = 0.0001f;

    private void Awake()
    {
        // Zabezpieczenie przed duplikacją obiektu przy przeładowaniu sceny
        DontDestroyOnLoad(gameObject);
        
        // Inicjalizacja sliderów
        InitializeSlider(_musicSlider, _musicVolumeKey, "Music");
        InitializeSlider(_sfxSlider, _sfxVolumeKey, "SFX");
    }

    private void InitializeSlider(Slider slider, string playerPrefKey, string mixerParameter)
    {
        // Ładowanie zapisanej wartości lub ustawienie domyślnej
        float savedVolume = PlayerPrefs.GetFloat(playerPrefKey, 0.75f);
        slider.value = savedVolume;

        // Ustawienie początkowej wartości w mixerze
        SetMixerVolume(mixerParameter, savedVolume);

        // Dodanie listenera do zmiany wartości
        slider.onValueChanged.AddListener((value) => 
        {
            SetMixerVolume(mixerParameter, value);
            PlayerPrefs.SetFloat(playerPrefKey, value);
            PlayerPrefs.Save();
        });
    }

    private void SetMixerVolume(string parameterName, float value)
    {
        // Konwersja wartości liniowej na logarytmiczną (dB)
        float volume = value <= _minVolume ? -80f : Mathf.Log10(value) * 20;
        _audioMixer.SetFloat(parameterName, volume);
    }

    // Opcjonalna metoda do resetowania ustawień
    public void ResetToDefaults()
    {
        PlayerPrefs.DeleteKey(_musicVolumeKey);
        PlayerPrefs.DeleteKey(_sfxVolumeKey);
        InitializeSlider(_musicSlider, _musicVolumeKey, "Music");
        InitializeSlider(_sfxSlider, _sfxVolumeKey, "SFX");
    }
}
