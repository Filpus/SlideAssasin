using System;
using UnityEngine;

public class ArcherEnemy : BaseEnemy
{

    [SerializeField] private Transform ArrowPrefab;
    protected override void Start()
    {
        base.Start();
        GameManager.TurnHappened += GameManagerOnTurnHappened;
    }

    private void GameManagerOnTurnHappened(object sender, EventArgs e)
    {
        Shot();
    }


    private void Shot()
    {
        
    }

    public override void Interact(Player player){}
}
