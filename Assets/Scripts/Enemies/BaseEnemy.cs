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


    [SerializeField] protected Direction frontDirection = Direction.Up;


    protected void Start()
    {
        switch (frontDirection)
        {
            case Direction.Up:
                transform.up = Vector2.up;
                break;
            case Direction.Down:
                transform.up = Vector2.down;
                break;
            case Direction.Left:
                transform.up = Vector2.left;
                break;
            case Direction.Right:
                transform.up = Vector2.right;
                break;
        }
    }


    public virtual void Interact(Player player){}
}
