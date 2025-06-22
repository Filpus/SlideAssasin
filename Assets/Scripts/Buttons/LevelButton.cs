using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    [SerializeField] private Button levelButton;
    public LevelSO LevelInfo;
    void Start()
    {
        levelButton.onClick.AddListener(Call);
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        print(unlockedLevel);
        print(LevelInfo.Number);
        print(LevelInfo.Number <= unlockedLevel);
        levelButton.interactable = LevelInfo.Number <= unlockedLevel;
    }

    private void Call()
    {
        MusicManager.Instance.PlayLevelMusic();
        print(LevelInfo);
        SceneManager.LoadScene(LevelInfo.Name);

    }


}
