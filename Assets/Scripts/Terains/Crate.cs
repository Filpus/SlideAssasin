using LDtkUnity;
using UnityEditor.Build;
using UnityEngine;

public class Crate : MonoBehaviour, ILDtkImportedEntity
{



    private BoxCollider2D _collider2D;
    public int  group_id;
    [SerializeField] private CrateAnimator _crateAnimator;
    public bool isOpen;

    
    public void OnLDtkImportEntity(EntityInstance entityInstance)
    {
        group_id = entityInstance.GetInt("crate_group");
        isOpen = entityInstance.GetBool("isOpen");
       
    }
    void Start()
    {

        _collider2D = this.GetComponent<BoxCollider2D>();
        SetState(isOpen);
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

    public void SetState(bool state)
    {
        if (state)
        {
            isOpen = true;
            Open();
        }
        else
        {
            isOpen = false;
            Close();
        }
    }
    public void SwitchState()
    {
        if (isOpen)
        {
            isOpen = false;
            Close();
        }
        else
        {
            isOpen = true;
            Open();
        }
    }
}
