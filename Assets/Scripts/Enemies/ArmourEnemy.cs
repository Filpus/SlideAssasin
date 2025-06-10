using System;
using Unity.VisualScripting;
using UnityEngine;

public class ArmourEnemy : BaseEnemy
{

    public enum ArmourState
    {
        Armored,
        Fragile
    }

    private ArmourState state = ArmourState.Armored;


    public override void Interact(Player player)
    {
        switch (state)
        {
            case ArmourState.Armored:
                state = ArmourState.Fragile;
                enemyAnimator.PlayEnemyAction();
                break;
            case ArmourState.Fragile:
                Destroy(gameObject);
                enemyAnimator.PlayEnemyDie();
                GameManager.Instance.EnemyDied();
                break;
        }
    }
}
