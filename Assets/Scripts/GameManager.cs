using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{



    [SerializeField] private int EnemyCounter = 10; //TODO Dodać SO inicjujący grę
    
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
    }


}
