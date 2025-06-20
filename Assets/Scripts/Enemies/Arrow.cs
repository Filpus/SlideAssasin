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
    [SerializeField] private float moveSpeed = 10f;
    public Direction ArrowDirection = Direction.Up;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void HandleMovement()
    // {
    //
    //     Vector2 moveDir = Vector2.zero;
    //     float moveDistance = moveSpeed * Time.deltaTime;
    //     switch (ArrowDirection)
    //     {
    //         case Direction.Up:
    //             moveDir = Vector2.up;
    //             break;
    //         case Direction.Down:
    //             moveDir = Vector2.down;
    //             break;
    //         case Direction.Left:
    //             moveDir = Vector2.left;
    //             break;
    //         case Direction.Right:
    //             moveDir = Vector2.right;
    //             break; 
    //     }
    //     float rotateSpeed = 20f;
    //     if(CanMove(moveDir, moveDistance))
    //     {
    //         Vector3 moveDir3 = new Vector3(moveDir.x, moveDir.y, 0f);
    //         transform.position += moveDir3 * moveDistance;
    //
    //     }
    //     else
    //     {
    //         TryToInteract(moveDir);
    //
    //     }
    //     
    //     
    // }
    // // private bool CanMove(Vector2 moveDir, float moveDistance)
    // {
    //     return moveDir != Vector2.zero && !Physics2D.Raycast(transform.position, moveDir, 1 / (float)2 + moveDistance , enemiesLayerMask | obstaclesLayer);
    //     
    //     
    // }
    // private bool TryToInteract(Vector2 moveDir)
    // {
    //     float interactionDistance = 1f;
    //     RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDir, interactionDistance, default);
    //     
    //     if (hit.collider != null)
    //     {
    //         IInteractable interactable = hit.collider.GetComponent<IInteractable>();
    //         if (interactable != null)
    //         {
    //             interactable.Interact(this);
    //             return true;
    //         }
    //     }
    //
    //     return false;
    // }
}
