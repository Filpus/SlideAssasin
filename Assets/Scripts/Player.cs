using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum MovementStates
    {
        MovingUp = 1,
        MovingDown = -1,
        MovingLeft = 2,
        MovingRight = -2,
        Standing = 0,
        Dead
    }
    
    
    public static Player Instance { get; private set; }
    
    
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask enemiesLayerMask;
    [SerializeField] private LayerMask obstaclesLayer;
    [SerializeField] private float moveSpeed = 10f;


    [SerializeField] private PlayerAnimator playerAnimator;
    
    public MovementStates playerMovementState;

    public static  event EventHandler PlayerMoved;

    private float playerSize = 1f;
    

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Jest wiele instancji gracza!");
        }

        Instance = this;
        playerMovementState = MovementStates.Standing;
    }

    private void Start()
    {
        GameInput.Instance.OnMoveUp += InstanceOnOnMoveUp;
        GameInput.Instance.OnMoveDown += InstanceOnOnMoveDown; 
        GameInput.Instance.OnMoveRight += InstanceOnOnMoveRight;
        GameInput.Instance.OnMoveLeft += InstanceOnOnMoveLeft;
    }



    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 moveDir = Vector2.zero;
        float moveDistance = moveSpeed * Time.deltaTime;
        switch (playerMovementState)
        {
            case MovementStates.MovingUp:
                moveDir = Vector2.up;
                break;
            case MovementStates.MovingDown:
                moveDir = Vector2.down;
                break;
            case MovementStates.MovingLeft:
                moveDir = Vector2.left;
                break;
            case MovementStates.MovingRight:
                moveDir = Vector2.right;
                break; 
        }
        float rotateSpeed = 20f;
        if(CanMove(moveDir, moveDistance))
        {
            Vector3 moveDir3 = new Vector3(moveDir.x, moveDir.y, 0f);
            transform.position += moveDir3 * moveDistance;

        }
        else
        {
            if (TryToInteract(moveDir))
            {
                playerAnimator.PlayAttack();
            }
            else
            {
                playerAnimator.PlayStop();
            }

            playerMovementState = MovementStates.Standing;
            AdjustPosition();
        }
        
        
    }


    public bool IsMoving()
    {
        return playerMovementState != MovementStates.Standing;
    }

    private bool CanMove(Vector2 moveDir, float moveDistance)
    {
        return moveDir != Vector2.zero && !Physics2D.Raycast(transform.position, moveDir, playerSize / (float)2 + moveDistance , enemiesLayerMask | obstaclesLayer);
        
        
    }

    private void AdjustPosition()
    {
        Vector3 position = transform.position;
        transform.position = new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0);
    }

    private bool TryToInteract(Vector2 moveDir)
    {
        float interactionDistance = 1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, interactionDistance, enemiesLayerMask);

        if (hit.collider != null)
        {
            BaseEnemy enemy = hit.collider.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                enemy.Interact(this);
                return true;
            }
        }

        return false;
    }


    public void Die()
    {
        playerAnimator.PlayDie();
        playerMovementState = MovementStates.Dead;
    }
    private void InstanceOnOnMoveUp(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing)
        {
            playerMovementState = MovementStates.MovingUp;
            PlayerMoved?.Invoke(this, EventArgs.Empty);
            playerAnimator.PlayRunUp();
        }
    }

    private void InstanceOnOnMoveDown(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing)
        {
            playerMovementState = MovementStates.MovingDown;
            PlayerMoved?.Invoke(this, EventArgs.Empty);
            playerAnimator.PlayRunDown();
        }    
    }

    private void InstanceOnOnMoveLeft(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing)
        {
            playerMovementState = MovementStates.MovingLeft;
            PlayerMoved?.Invoke(this, EventArgs.Empty);
            playerAnimator.PlayRunLeft();
        }
    }

    private void InstanceOnOnMoveRight(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing)
        {
            playerMovementState = MovementStates.MovingRight;
            PlayerMoved?.Invoke(this, EventArgs.Empty);
            playerAnimator.PlayRunRight();
        }
    }
    

}
