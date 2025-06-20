using UnityEngine;

public class ArrowAnimator : MonoBehaviour
{
    private Animator animator;
    private const string DIRECTION = "Direction";

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        
    }    
    
    public void SetDirection(Arrow.Direction direction)
    {
        animator.SetInteger(DIRECTION, (int)direction);
    }

    
    
}
