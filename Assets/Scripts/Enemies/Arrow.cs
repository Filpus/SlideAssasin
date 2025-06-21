using UnityEngine;

public class Arrow : MonoBehaviour
{
    public enum Direction
    {
        Up = 1,
        Down = -1,
        Left = 2,
        Right = -2
    }
    
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private LayerMask obstaclesLayer;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private ArrowAnimator _arrowAnimator;
    public Direction ArrowDirection = Direction.Up;
    
    
    private Vector2 moveDirection;
    private Collider2D arrowCollider;

    void Start()
    {
        SetMoveDirection();
        arrowCollider = GetComponent<Collider2D>();
        
        // Automatyczne zniszczenie strzały po 10 sekundach (zabezpieczenie)
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        HandleMovement();
    }

    private void SetMoveDirection()
    {
        switch (ArrowDirection)
        {
            case Direction.Up:
                moveDirection = Vector2.up;
                break;
            case Direction.Down:
                moveDirection = Vector2.down;
                break;
            case Direction.Left:
                moveDirection = Vector2.left;
                break;
            case Direction.Right:
                moveDirection = Vector2.right;
                break;
        }
        _arrowAnimator.SetDirection(ArrowDirection);
    }

    private void HandleMovement()
    {
        float moveDistance = moveSpeed * Time.deltaTime;
        
        if (CanMove(moveDirection, moveDistance))
        {
            transform.Translate(moveDirection * moveDistance);
        }
        else
        {
            // Próba interakcji przed zniszczeniem
            if (!TryToInteract(moveDirection))
            {
                DestroyArrow();
            }
        }
    }

    private bool CanMove(Vector2 moveDir, float moveDistance)
    {
        return moveDir != Vector2.zero && 
               !Physics2D.Raycast(transform.position, moveDir, moveDistance + 0.1f, obstaclesLayer | playerLayer);
    }

    private bool TryToInteract(Vector2 moveDir)
    {
        float interactionDistance = 0.25f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, interactionDistance, obstaclesLayer | playerLayer);
        
        if (hit.collider != null)
        {
            // Sprawdzenie czy trafiliśmy gracza
            if (IsInLayerMask(hit.collider.gameObject.layer, playerLayer))
            {
                // Wywołanie śmierci gracza
                if (Player.Instance != null)
                {
                    Player.Instance.Die();
                }
                DestroyArrow();
                return true;
            }
            // Sprawdzenie czy trafiliśmy przeszkodę lub wroga
            else if (IsInLayerMask(hit.collider.gameObject.layer, obstaclesLayer))
            {
                DestroyArrow();
                return true;
            }
        }
        
        return false;
    }

    private bool IsInLayerMask(int layer, LayerMask layerMask)
    {
        return (layerMask.value & (1 << layer)) != 0;
    }

    public void SetLayerMasks(LayerMask obstacles, LayerMask player)
    {
        obstaclesLayer = obstacles;
        playerLayer = player;
    }

    private void DestroyArrow()
    {
        Destroy(gameObject);
    }

    // Alternatywna metoda używająca OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzenie czy strzała ma ustawiony trigger
        if (arrowCollider != null && arrowCollider.isTrigger)
        {
            if (IsInLayerMask(other.gameObject.layer, playerLayer))
            {
                if (Player.Instance != null)
                {
                    Player.Instance.Die();
                }
                DestroyArrow();
            }
            else if (IsInLayerMask(other.gameObject.layer, obstaclesLayer))
            {
                DestroyArrow();
            }
        }
    }
}
