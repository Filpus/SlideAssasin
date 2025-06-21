using UnityEngine;

public class ShieldEnemy : BaseEnemy
{

    public override bool Interact(Player player)
    {
        if ((int)this.frontDirection != (int)player.playerMovementState * -1)
        {
            _collider2D.enabled = false;

            enemySound?.PlaySound();
            enemyAnimator.PlayEnemyDie(); 
            GameManager.Instance.EnemyDied();

            
            return true;
        }

        return false;
    }
    
    
}
