using System;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{

    public enum Direction
    {
        Up = 1,
        Down = -1,
        Left = 2,
        Right = -2
    }

    [SerializeField] protected EnemyAnimator enemyAnimator;

    [SerializeField] protected Direction frontDirection = Direction.Up;


    protected void Start()
    {

        enemyAnimator.SetDirection(frontDirection);
        AdjustPosition();
    }


    public virtual void Interact(Player player){}
    private void AdjustPosition()
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0);
    }
}
