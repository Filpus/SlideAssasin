using System;
using UnityEngine;

public class ArcherEnemy : BaseEnemy
{

    [SerializeField] private Transform ArrowPrefab;
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.TurnHappened += GameManagerOnTurnHappened;
    }

    private void GameManagerOnTurnHappened(object sender, EventArgs e)
    {
        Shot();
    }


    private void Shot()
    {
        
    }

    public override bool Interact(Player player)
    {
        enemyAnimator.PlayEnemyDie();
        
        GameManager.Instance.EnemyDied();
        _collider2D.enabled = false;

        return true;
    }
}
