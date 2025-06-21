using UnityEngine;

public class LvlExitAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string OPEN = "Open";

    void Start()
    {
        this._animator = this.GetComponent<Animator>();
    }


    public void Open()
    {
        _animator.SetTrigger(OPEN);
    }


}
