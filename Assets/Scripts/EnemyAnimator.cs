using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    private const string DIRECTION = "Direction";
    private const string DIE = "Die";
    private const string ACTION = "Action";
    
    private Animator animator;

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


    public void SetDirection(BaseEnemy.Direction direction)
    {
        animator.SetInteger(DIRECTION, (int)direction);
    }


    public void PlayEnemyDie()
    {
        animator.SetTrigger(DIE);

    }

    public void PlayEnemyAction()
    {
        animator.SetTrigger(ACTION);
    }
}
