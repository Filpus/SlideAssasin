using UnityEngine;

public class LvlExitVisual : MonoBehaviour
{

    [SerializeField] private Transform ActiveVisual;
    [SerializeField] private Transform UnActiveVisual;
    void Start()
    {
        UnActiveVisual.gameObject.SetActive(true);
        ActiveVisual.gameObject.SetActive(false);
    }


    public void ShowActive()
    {
        UnActiveVisual.gameObject.SetActive(false);
        ActiveVisual.gameObject.SetActive(true);
    }

    public void ShowUnactive()
    {
        UnActiveVisual.gameObject.SetActive(true);
        ActiveVisual.gameObject.SetActive(false);
    }
    
}
