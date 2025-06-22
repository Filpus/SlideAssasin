using System;
using UnityEngine;

public class DangerPointAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string CHANGE_STATE = "ChangeState";

    void Start()
    {
        this._animator = this.GetComponent<Animator>();
    }


    public void ChangeState()
    {
        _animator.SetTrigger(CHANGE_STATE);
    }

}
