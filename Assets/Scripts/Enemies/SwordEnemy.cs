using UnityEngine;

public class SwordEnemy : BaseEnemy
{
    public override void Interact(Player player)
    {
        GameManager.Instance.EnemyDied();
        Destroy(gameObject);
    }
}
