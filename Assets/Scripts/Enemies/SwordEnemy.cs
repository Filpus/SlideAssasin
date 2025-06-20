using UnityEngine;

public class SwordEnemy : BaseEnemy
{
    public override bool Interact(Player player)
    {
        GameManager.Instance.EnemyDied();
        Destroy(gameObject);
        return true;
    }
}
