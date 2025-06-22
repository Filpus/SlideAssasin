using LDtkUnity;
using UnityEngine;

public class DangerPoint : MonoBehaviour, ILDtkImportedEntity
{


    private bool isActive = false;
    private int groupId = 0;
    [SerializeField] private DangerPointAnimator _pointAnimator;

    public void OnLDtkImportEntity(EntityInstance entityInstance)
    {
        groupId = entityInstance.GetInt("group_id");
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
