using UnityEngine;
using UnityEngine.Serialization;

public class MenuManager : MonoBehaviour
{
    
    
    [SerializeField] private Transform MenuView;
    [SerializeField] private Transform OptionsView;
    [SerializeField] private Transform Background;
    [SerializeField] private Transform WinScreen;
    [SerializeField] private Transform PlayerDeath;

    public void HideAll()
    {
        MenuView.gameObject.SetActive(false);
        OptionsView.gameObject.SetActive(false);
        Background.gameObject.SetActive(false);
        PlayerDeath.gameObject.SetActive(false);
    }

    public void ShowMenu()
    {
        MenuView.gameObject.SetActive(true);
        Background.gameObject.SetActive(true);
    }

    public void ShowWinScreen()
    {
        WinScreen.gameObject.SetActive(true);
    }

    public void ShowDeathScreen()
    {
        PlayerDeath.gameObject.SetActive(true);

    }
}
