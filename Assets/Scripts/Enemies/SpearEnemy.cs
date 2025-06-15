using UnityEngine;

public class SpearEnemy : BaseEnemy
{

    public override void Interact(Player player)
    {
        if ((int)this.frontDirection == (int)player.playerMovementState * -1)
        {
            print("dada");
            enemyAnimator.PlayEnemyAction();
            player.Die();
        }
        else
        {
            print("dudu");
            enemyAnimator.PlayEnemyDie();
            GameManager.Instance.EnemyDied();
            Destroy(gameObject);
        }
    }
    
}
