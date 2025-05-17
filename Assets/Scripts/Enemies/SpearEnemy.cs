using UnityEngine;

public class SpearEnemy : BaseEnemy
{

    public override void Interact(Player player)
    {
        if ((int)this.frontDirection == (int)player.playerMovementState * -1)
        {
          Debug.Log("Przegrałeś!");  
          player.Die();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
