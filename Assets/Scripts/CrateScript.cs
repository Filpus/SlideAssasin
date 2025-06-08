using LDtkUnity;
using UnityEngine;

public class CrateScript : MonoBehaviour, ILDtkImportedEntity
{
    [SerializeField] bool isOpen= false;
    void Start()
    {
        
    }
    public void OnLDtkImportEntity(EntityInstance entity)
    {
        isOpen = entity.GetBool("isOpen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
