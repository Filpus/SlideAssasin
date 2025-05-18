using System;
using UnityEngine;

public class ArcherEnemy : BaseEnemy
{

    [SerializeField] private Transform ArrowPrefab;
    protected void Start()
    {
        GameManager.TurnHappened += GameManagerOnTurnHappened;
    }

    private void GameManagerOnTurnHappened(object sender, EventArgs e)
    {
        Shot();
    }


    private void Shot()
    {
        
    }

    public virtual void Interact(Player player){}
}
