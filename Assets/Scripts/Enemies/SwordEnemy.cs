using UnityEngine;

public class SwordEnemy : BaseEnemy
{
    public override void Interact(Player player)
    {
        Destroy(gameObject);
    }
}
