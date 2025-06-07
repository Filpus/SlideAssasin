using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    [SerializeField] private Scene level;
    [SerializeField] private Button levelButton;
    public bool IsUnlock = false; 
    void Start()
    {
        levelButton.onClick.AddListener(Call);
        levelButton.enabled = IsUnlock;
    }

    private void Call()
    {
        SceneManager.LoadScene(level.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
