using TMPro;
using UnityEngine;

public class ColumnAnimator : MonoBehaviour
{


    private const string NUMBER_OF_HITS = "NumberOfHits";
    private Animator _animator;
    
    void Start()
    {
        this._animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void SetNumberOfHits(int numberOfHits)
    {
        _animator.SetInteger(NUMBER_OF_HITS, numberOfHits);
    }
}
