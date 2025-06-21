using System;
using UnityEngine;
using LDtkUnity;
using Utils;
using Enemies;
using JetBrains.Annotations;

public class BaseEnemy : MonoBehaviour, ILDtkImportedEntity, IInteractable
{

    public enum Direction
    {
        Up = 1,
        Down = -1,
        Left = 2,
        Right = -2
    }

    [SerializeField] protected EnemyAnimator enemyAnimator;

    [SerializeField] protected Direction frontDirection=Direction.Up;
    [SerializeField] [CanBeNull] protected BaseSound enemySound;

    
    protected Collider2D _collider2D;
    public void OnLDtkImportEntity(EntityInstance entity)
    {
        UnityEngine.Debug.Log("OnLDtkImportEntity called");
        int sideValue = entity.GetInt("Side");
        UnityEngine.Debug.Log("Side value: " + sideValue);

        switch (sideValue)
        {
            case 1:
                frontDirection = Direction.Up;
                break;

            case 2:
                frontDirection = Direction.Left;
                break;

            case -1:
                frontDirection = Direction.Down;
                break;

            case -2:
                frontDirection = Direction.Right;
                break;
            default:
                frontDirection = Direction.Up;
                break;
        }
        print("Init, side: " + frontDirection);
    }

    protected virtual void Start()
    {

        enemyAnimator.SetDirection(frontDirection);
        _collider2D = GetComponent<Collider2D>();
        AdjustPosition();
    }


    public virtual bool Interact(Player player)
    {
        return true;
    }
    private void AdjustPosition()
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(RoundToNearestHalf(position.x), RoundToNearestHalf(position.y), 0);
    }

    float RoundToNearestHalf(double value)
    {
        return (float)Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
    }
}
