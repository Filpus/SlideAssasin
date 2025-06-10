using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{




    [SerializeField] public LevelSO levelInfo;

    [SerializeField] private MenuManager _menuManager;
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
        GameInput.Instance.OnPause += InstanceOnOnPause;
        GameInput.Instance.OnReset += InstanceOnOnReset;
        levelExit.OnEndLevel += LevelExitOnOnEndLevel;
    }

    private void LevelExitOnOnEndLevel(object sender, EventArgs e)
    {
        IsPaused = true;
        _menuManager.ShowWinScreen();
        PlayerPrefs.SetInt("UnlockedLevel", levelInfo.Number + 1);
    }

    private void InstanceOnOnReset(object sender, EventArgs e)
    {
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


}
