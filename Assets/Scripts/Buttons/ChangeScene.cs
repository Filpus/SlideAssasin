using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private string SceneName;
    void Start()
    {
        button.onClick.AddListener(Call);
    }

    private void Call()
    {
        SceneManager.LoadScene(SceneName);

    }
}
