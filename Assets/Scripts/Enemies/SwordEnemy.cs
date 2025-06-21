using UnityEngine;

public class SwordEnemy : BaseEnemy
{
    public override bool Interact(Player player)
    {
        
        _collider2D.enabled = false;
        GameManager.Instance.EnemyDied();
        enemyAnimator.PlayEnemyDie();
        return true;
    }
}
