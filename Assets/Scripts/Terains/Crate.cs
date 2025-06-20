using LDtkUnity;
using UnityEngine;

public class Crate : MonoBehaviour, ILDtkImportedEntity
{



    private BoxCollider2D _collider2D;
    [SerializeField] private CrateAnimator _crateAnimator;

    
    public void OnLDtkImportEntity(EntityInstance entityInstance)
    {
        
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
