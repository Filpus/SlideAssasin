using UnityEngine;

public class SpearEnemy : BaseEnemy
{

    public override bool Interact(Player player)
    {
        if ((int)this.frontDirection == (int)player.playerMovementState * -1)
        {
            enemyAnimator.PlayEnemyAction();
            player.Die();
            return false;
        }
        else
        {
            _collider2D.enabled = false;
            GameManager.Instance.EnemyDied();
            enemyAnimator.PlayEnemyDie();

            return true;
        }
    }
    
}
