using UnityEngine;

public class ShieldEnemy : BaseEnemy
{

    public override bool Interact(Player player)
    {
        if ((int)this.frontDirection != (int)player.playerMovementState * -1)
        {
            
            enemyAnimator.PlayEnemyDie();
            GameManager.Instance.EnemyDied();
            Destroy(gameObject);
            enemySound?.PlaySound();
            
            return true;
        }

        return false;
    }
    
    
}
