using UnityEngine;

public class SpearEnemy : BaseEnemy
{

    public override void Interact(Player player)
    {
        if ((int)this.frontDirection == (int)player.playerMovementState * -1)
        {
            enemyAnimator.PlayEnemyAction();
            player.Die();
        }
        else
        {
            enemyAnimator.PlayEnemyDie();
            Destroy(gameObject);
        }
    }
    
}
