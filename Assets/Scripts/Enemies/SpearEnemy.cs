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
            enemyAnimator.PlayEnemyDie();
            GameManager.Instance.EnemyDied();
            Destroy(gameObject);
            return true;
        }
    }
    
}
