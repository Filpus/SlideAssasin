using System;
using LDtkUnity;
using UnityEngine;
using Utils;

public class Column : MonoBehaviour, ILDtkImportedEntity, IInteractable
{

    private int _hitNumber = 0;
    [SerializeField] private ColumnAnimator _animator;
    public event EventHandler ColumnDestroyed; 
    
    
    public void OnLDtkImportEntity(EntityInstance entityInstance)
    {
        
    }



    public bool Interact(Player player)
    {

        if (_hitNumber < 3)
        {
            _animator.SetNumberOfHits(++_hitNumber);

            if (_hitNumber == 3)
            {
                ColumnDestroyed?.Invoke(this,EventArgs.Empty);
            }
        }

        return true;
    }
}
