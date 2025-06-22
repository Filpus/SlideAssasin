using LDtkUnity;
using UnityEngine;

public class Crate : MonoBehaviour, ILDtkImportedEntity
{



    private BoxCollider2D _collider2D;
    private int  group_id = 0;
    [SerializeField] private CrateAnimator _crateAnimator;

    
    public void OnLDtkImportEntity(EntityInstance entityInstance)
    {
        group_id = entityInstance.GetInt("group_id");
        this._collider2D.enabled = entityInstance.GetBool("is_open");
       
    }
    void Start()
    {

        _collider2D = this.GetComponent<BoxCollider2D>();
    }


    public void Open()
    {
        this._collider2D.enabled = false;
        _crateAnimator.Open();
        
    }

    public void Close()
    {
        this._collider2D.enabled = true;
        _crateAnimator.Close();
    }
}
