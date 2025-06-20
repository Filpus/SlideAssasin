using System;
using UnityEngine;

public class DangerPointAnimator : MonoBehaviour
{
    private Animator _animator;
    private const string IS_Acive = "IsActive";

    void Start()
    {
        this._animator = this.GetComponent<Animator>();
    }


    public void Active()
    {
        _animator.SetBool(IS_Acive,true );
    }

    public void Disactive()
    {
        _animator.SetBool(IS_Acive, false);
    }


}
