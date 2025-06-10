using UnityEngine;
using UnityEngine.UI;

public class GameExit : MonoBehaviour
{
    [SerializeField] private Button button;
    void Start()
    {
        button.onClick.AddListener(Call);
    }

    private void Call()
    {
        // Wyjście z gry (działa tylko w buildzie, nie w edytorze)
        Application.Quit();

            // Opcjonalnie, aby zobaczyć efekt w edytorze (do testów)
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
