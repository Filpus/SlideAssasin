using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    [SerializeField] private int EnemyCounter = 3; //TODO Dodać SO inicjujący grę

    public static event EventHandler LevelCleared;
    
    public static GameManager Instance;
    public static event EventHandler TurnHappened;
    void Awake()
    {
        Instance = this;
        Player.PlayerMoved += PlayerOnPlayerMoved;
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
