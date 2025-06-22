using System;
using UnityEngine;

public class ArcherEnemy : BaseEnemy
{

    [SerializeField] private GameObject ArrowPrefab;
    [SerializeField] private Transform UpArrowSpawnPoint;
    [SerializeField] private Transform DownArrowSpawnPoint;
    [SerializeField] private Transform LeftArrowSpawnPoint;
    [SerializeField] private Transform RightArrowSpawnPoint;
    
    [SerializeField] private LayerMask obstaclesLayer;
    [SerializeField] private LayerMask playerLayer;

    private bool IsReady = false;
    protected override void Start()
    {
        base.Start();
        GameManager.Instance.TurnHappened += GameManagerOnTurnHappened;
    }

    private void GameManagerOnTurnHappened(object sender, EventArgs e)
    {
        if (IsReady)
        {
            Shot();
            IsReady = false;
            enemyAnimator.PlayEnemyAction();
        }
        else
        {
            IsReady = true;
            enemyAnimator.PlayEnemyAction();

        }
    }


    private void Shot()
    {
        Transform spawnPoint = GetSpawnPointForDirection();
        if (spawnPoint != null && ArrowPrefab != null)
        {
            // Tworzenie strzały w odpowiednim punkcie spawn
            GameObject arrow = Instantiate(ArrowPrefab, spawnPoint.position, spawnPoint.rotation);
            Arrow arrowScript = arrow.GetComponent<Arrow>();
            
            if (arrowScript != null)
            {
                // Ustawienie kierunku strzały zgodnie z kierunkiem łucznika
                arrowScript.ArrowDirection = (Arrow.Direction)(int)frontDirection;
                arrowScript.SetLayerMasks(obstaclesLayer, playerLayer);
            }
        }
    }
    
    private Transform GetSpawnPointForDirection()
    {
        switch (frontDirection)
        {
            case Direction.Up:
                return UpArrowSpawnPoint;
            case Direction.Down:
                return DownArrowSpawnPoint;
            case Direction.Left:
                return LeftArrowSpawnPoint;
            case Direction.Right:
                return RightArrowSpawnPoint;
            default:
                return UpArrowSpawnPoint;
        }
    }

    public override bool Interact(Player player)
    {
        enemyAnimator.PlayEnemyDie();
        
        GameManager.Instance.EnemyDied();
        _collider2D.enabled = false;

        return true;
    }

    public void OnDestroy()
    {
        GameManager.Instance.TurnHappened -= GameManagerOnTurnHappened;
    }
}
