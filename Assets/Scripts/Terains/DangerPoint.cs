using LDtkUnity;
using UnityEngine;

public class DangerPoint : MonoBehaviour, ILDtkImportedEntity
{


    private bool isActive = false;
    [SerializeField] private DangerPointAnimator _pointAnimator;

    public void OnLDtkImportEntity(EntityInstance entityInstance)
    {
        
    }




    public void Active()
    {
        isActive = true;
        _pointAnimator.Active();
    }

    public void Disactive()
    {
        isActive = false;
        _pointAnimator.Disactive();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Player.Instance.Die();
    }
}
