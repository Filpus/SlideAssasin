using LDtkUnity;
using UnityEngine;

public class DangerPoint : MonoBehaviour, ILDtkImportedEntity
{

    public enum DangerPointState
    {
        Safe,
        Preparing,
        Active
    }

    private bool isActive = false;
    public int groupId = 0;
    [SerializeField] private DangerPointVisual _dangerPointVisual;


    DangerPointState PointState = DangerPointState.Safe;
    public void OnLDtkImportEntity(EntityInstance entityInstance)
    {
        groupId = entityInstance.GetInt("group_id");
    }


    public void StartPreparing()
    {
        if (PointState == DangerPointState.Safe)
        {
            PointState = DangerPointState.Preparing;
            _dangerPointVisual.ChangeState(PointState);
        }
    }


    public void MakeProgress()
    {
        if (PointState == DangerPointState.Preparing)
        {
            PointState = DangerPointState.Active;
            _dangerPointVisual.ChangeState(PointState);

        } else if (PointState == DangerPointState.Active)
        {
            PointState = DangerPointState.Safe;
            _dangerPointVisual.ChangeState(PointState);

        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PointState == DangerPointState.Active)
        {
            Player.Instance.Die();
        }
    }
}
