using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    private const string DIE = "Die";
    private const string RUN_LEFT = "RunLeft";
    private const string RUN_RIGHT = "RunRight";
    private const string RUN_DOWN = "RunDown";
    private const string RUN_UP = "RunUp";
    private const string STOP = "Stop";
    private const string ATTACK = "Attack";
    
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }



    public void PlayDie()
    {
        animator.SetTrigger(DIE);
    }

    public void PlayRunLeft()
    {
        animator.SetTrigger(RUN_LEFT);
    }

    public void PlayRunRight()
    {
        animator.SetTrigger(RUN_RIGHT);
    }

    public void PlayRunDown()
    {
        animator.SetTrigger(RUN_DOWN);
    }

    public void PlayRunUp()
    {
        animator.SetTrigger(RUN_UP);
    }

    public void PlayStop()
    {
        animator.SetTrigger(STOP);
    }

    public void PlayAttack()
    {
        animator.SetTrigger(ATTACK);
    }
}
