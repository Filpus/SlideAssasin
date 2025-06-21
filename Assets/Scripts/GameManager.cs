using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{




    [SerializeField] public LevelSO levelInfo;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private DialogManager _dialogManager;
    private int EnemyCounter;
    public  event EventHandler LevelCleared;
    
    public static GameManager Instance;

    [SerializeField] private LvlExit levelExit;
    public  event EventHandler TurnHappened;
    public bool IsPaused = false;
    void Awake()
    {
        Instance = this;
        EnemyCounter = levelInfo.EnemyNumber;

    }

    private void Start()
    {
        Player.Instance.PlayerMoved += PlayerOnPlayerMoved;
        Player.Instance.PlayerDie += InstanceOnPlayerDie;
        GameInput.Instance.OnPause += InstanceOnOnPause;
        GameInput.Instance.OnReset += InstanceOnOnReset;
        levelExit.OnEndLevel += LevelExitOnOnEndLevel;
    }

    private void InstanceOnPlayerDie(object sender, EventArgs e)
    {
        IsPaused = true;
        _menuManager.ShowDeathScreen();
    }

    private void LevelExitOnOnEndLevel(object sender, EventArgs e)
    {
        IsPaused = true;
        if( levelInfo.Dialog !="")
        {
            _dialogManager.ShowDialog(levelInfo.Dialog);
        }
        _menuManager.ShowWinScreen();
        PlayerPrefs.SetInt("UnlockedLevel", levelInfo.Number + 1);
    }

    private void InstanceOnOnReset(object sender, EventArgs e)
    {
        Restart();
    }

    private void InstanceOnOnPause(object sender, EventArgs e)
    {
        if (IsPaused)
        {
            _menuManager.HideAll();    
        }
        else
        {
            _menuManager.ShowMenu();
        }

        IsPaused = !IsPaused;
        
        
    }

    private void PlayerOnPlayerMoved(object sender, EventArgs e)
    {
        TurnHappened?.Invoke(this, EventArgs.Empty);
    }

    public void EnemyDied()
    {
        EnemyCounter--;
        if (EnemyCounter <= 0)
        {
            LevelCleared?.Invoke(this, EventArgs.Empty);
        }
    }

    public void Restart()
    {
        
    }


}
