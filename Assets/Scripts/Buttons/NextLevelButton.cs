using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelButton : MonoBehaviour
{
    [SerializeField] private Button levelButton;
    void Start()
    {
        levelButton.onClick.AddListener(OnClick);
    }


    private void OnClick()
    {
        SceneManager.LoadScene(GameManager.Instance.levelInfo.NextLevelName);

    }
}
