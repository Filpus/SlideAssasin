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


    public override bool Interact(Player player)
    {
        switch (state)
        {
            case ArmourState.Armored:
                state = ArmourState.Fragile;
                enemyAnimator.PlayEnemyAction();
                return false;
                
            case ArmourState.Fragile:
                enemyAnimator.PlayEnemyDie();
                GameManager.Instance.EnemyDied();
                _collider2D.enabled = false;
                return true;
        }

        return false;
    }
}
