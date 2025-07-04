using System;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using Utils;

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
    [SerializeField] private PlayerAudio playerAudio;
    
    public MovementStates playerMovementState;

    public  event EventHandler PlayerMoved;
    public event EventHandler PlayerDie;
    public event EventHandler PlayerEndMovement;

    private float playerSize = 1f;
    

    private void Awake()
    {
        if (Instance != null)
        {
            GameInput.Instance.OnMoveUp -= Instance.InstanceOnOnMoveUp;
            GameInput.Instance.OnMoveDown -= Instance.InstanceOnOnMoveDown;
            GameInput.Instance.OnMoveRight -= Instance.InstanceOnOnMoveRight;
            GameInput.Instance.OnMoveLeft -= Instance.InstanceOnOnMoveLeft;
            Instance.PlayerDie = null;
            Instance.PlayerMoved = null;
            Instance.PlayerEndMovement = null;


            Destroy(Player.Instance.gameObject);
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

            if (MovementStates.Standing != playerMovementState)
            {
                if (CanMove(moveDir, moveDistance/2))
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
                    PlayerEndMovement?.Invoke(this,EventArgs.Empty);
                }
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
        transform.position = new Vector3(RoundToNearestHalf(position.x), RoundToNearestHalf(position.y), 0);
    }

    float RoundToNearestHalf(double value)
    {
        return (float)Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
    }

    private bool TryToInteract(Vector2 moveDir)
    {
        float interactionDistance = 1f;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, interactionDistance, enemiesLayerMask);

        if (hit.collider != null)
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (interactable.Interact(this))
                {
                    playerAudio.PlayAttack();
                };
                return true;
            }
        }

        return false;
    }


    public void Die()
    {
        playerAnimator.PlayDie();
        playerMovementState = MovementStates.Dead;
        PlayerDie?.Invoke(this, EventArgs.Empty);
    }
    private void InstanceOnOnMoveUp(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing &! GameManager.Instance.IsPaused & (playerMovementState != MovementStates.Dead))
        {
            float moveDistance = moveSpeed * Time.deltaTime;

            if (CanMove(Vector2.up, moveDistance))
            {
                playerMovementState = MovementStates.MovingUp;
                
                PlayerMoved?.Invoke(this, EventArgs.Empty);
                playerAnimator.PlayRunUp();
                playerAudio.PlayDash();
            }

        }
    }

    private void InstanceOnOnMoveDown(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing &! GameManager.Instance.IsPaused & (playerMovementState != MovementStates.Dead))
        {
            float moveDistance = moveSpeed * Time.deltaTime;

            if (CanMove(Vector2.down, moveDistance))
            {
                playerMovementState = MovementStates.MovingDown;
                PlayerMoved?.Invoke(this, EventArgs.Empty);
                playerAnimator.PlayRunDown();
                playerAudio.PlayDash();
            }
        }    
    }

    private void InstanceOnOnMoveLeft(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing &! GameManager.Instance.IsPaused & (playerMovementState != MovementStates.Dead))
        {
            float moveDistance = moveSpeed * Time.deltaTime;

            if (CanMove(Vector2.left, moveDistance))
            {
                playerMovementState = MovementStates.MovingLeft;
                PlayerMoved?.Invoke(this, EventArgs.Empty);
                playerAnimator.PlayRunLeft();
                playerAudio.PlayDash();
            }
        }
    }

    private void InstanceOnOnMoveRight(object sender, EventArgs e)
    {
        if (playerMovementState == MovementStates.Standing &! GameManager.Instance.IsPaused & (playerMovementState != MovementStates.Dead))
        {
            float moveDistance = moveSpeed * Time.deltaTime;

            if (CanMove(Vector2.right, moveDistance))
            {
                playerMovementState = MovementStates.MovingRight;
                PlayerMoved?.Invoke(this, EventArgs.Empty);
                playerAnimator.PlayRunRight();
                playerAudio.PlayDash();
            }
        }
    }

    public void OnDestroy()
    {
        GameInput.Instance.OnMoveUp -= InstanceOnOnMoveUp;
        GameInput.Instance.OnMoveDown -= InstanceOnOnMoveDown;
        GameInput.Instance.OnMoveRight -= InstanceOnOnMoveRight;
        GameInput.Instance.OnMoveLeft -= InstanceOnOnMoveLeft;

        if (Instance == this)
    {
        Instance = null;
    }
    }
}

