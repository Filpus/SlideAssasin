using UnityEngine;

public class CrateAnimator : MonoBehaviour
{

    private Animator _animator;
    private const string IS_OPEN = "IsOpen";

    void Start()
    {
        this._animator = this.GetComponent<Animator>();
    }


    public void Open()
    {
        _animator.SetBool(IS_OPEN,true );
    }

    public void Close()
    {
        _animator.SetBool(IS_OPEN, false);
    }
}
