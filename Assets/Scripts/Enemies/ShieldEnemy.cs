using UnityEngine;

public class ShieldEnemy : BaseEnemy
{

    public override void Interact(Player player)
    {
        if ((int)this.frontDirection != (int)player.playerMovementState * -1)
        {
            
            enemyAnimator.PlayEnemyDie();
            Destroy(gameObject);
        }
    }
    
}
