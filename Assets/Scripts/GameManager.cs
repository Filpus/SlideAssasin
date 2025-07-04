﻿using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    [SerializeField] public Transform level;
    [SerializeField] public LevelSO levelInfo;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private DialogManager _dialogManager;
    private int EnemyCounter;
    public event EventHandler LevelCleared;

    public static GameManager Instance;

    public event EventHandler TurnHappened;
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
        LvlExit.Instance.OnEndLevel += LevelExitOnOnEndLevel;
    }

    private void InstanceOnPlayerDie(object sender, EventArgs e)
    {
        IsPaused = true;
        _menuManager.ShowDeathScreen();
    }

    public void LevelExitOnOnEndLevel(object sender, EventArgs e)
    {
        IsPaused = true;
        if (levelInfo.Dialog != "")
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

    public void Restart()
    {
        Vector3 oldPosition = level.transform.position;
        Quaternion oldRotation = level.transform.rotation;
        Destroy(level.gameObject);

        Player.Instance.PlayerMoved -= PlayerOnPlayerMoved;
        Player.Instance.PlayerDie -= InstanceOnPlayerDie;

        level = Instantiate(levelInfo.LevelPrefab, oldPosition, oldRotation);
        EnemyCounter = levelInfo.EnemyNumber;

        Player.Instance.PlayerMoved += PlayerOnPlayerMoved;
        Player.Instance.PlayerDie += InstanceOnPlayerDie;
        
        _menuManager.HideAll();
        IsPaused = false;
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
