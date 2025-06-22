using UnityEngine;

namespace Enemies
{
    public class BossAnimator: MonoBehaviour
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
}