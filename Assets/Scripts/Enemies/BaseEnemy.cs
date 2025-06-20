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
        AdjustPosition();
    }


    public virtual bool Interact(Player player)
    {
        return true;
    }
    private void AdjustPosition()
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0);
    }
}
