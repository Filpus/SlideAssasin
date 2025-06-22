using UnityEngine;

public class DangerPointVisual : MonoBehaviour
{
    [SerializeField] private Transform PreparingVisual;
    [SerializeField] private Transform ActiveVisual;
    void Start()
    {
        PreparingVisual.gameObject.SetActive(false);
        ActiveVisual.gameObject.SetActive(false);
    }



    public void ChangeState(DangerPoint.DangerPointState state)
    {
        switch (state)
        {
            case DangerPoint.DangerPointState.Safe:
                Hide();
                break;
            case DangerPoint.DangerPointState.Preparing:
                ShowPreparing();
                break;
            case DangerPoint.DangerPointState.Active:
                ShowActive();
                break;
            
        }
    }
    
    public void ShowPreparing()
    {
        PreparingVisual.gameObject.SetActive(true);
        ActiveVisual.gameObject.SetActive(false);
    }

    public void ShowActive()
    {
        PreparingVisual.gameObject.SetActive(false);
        ActiveVisual.gameObject.SetActive(true);
    }

    public void Hide()
    {
        PreparingVisual.gameObject.SetActive(false);
        ActiveVisual.gameObject.SetActive(false);
    }

}
