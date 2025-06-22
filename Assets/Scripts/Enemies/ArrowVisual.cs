using UnityEngine;

public class ArrowVisual : MonoBehaviour
{

    [SerializeField] private Transform ArrowHorizontal;
    [SerializeField] private Transform ArrowVertical;

    
    void Awake()
    {
        
    }    
    
    public void SetDirection(Arrow.Direction direction)
    {
        switch (direction)
        {
            case Arrow.Direction.Up:
                ArrowVertical.gameObject.SetActive(true);
                ArrowHorizontal.gameObject.SetActive(false);
                break;
            case Arrow.Direction.Down:
                ArrowVertical.gameObject.SetActive(true);
                ArrowHorizontal.gameObject.SetActive(false);
                ArrowVertical.GetComponent<SpriteRenderer>().flipY = true;
                break;
            case Arrow.Direction.Left:
                ArrowVertical.gameObject.SetActive(false);
                ArrowHorizontal.gameObject.SetActive(true);
                ArrowHorizontal.GetComponent<SpriteRenderer>().flipX = true;
                break;
            case Arrow.Direction.Right:
                ArrowVertical.gameObject.SetActive(false);
                ArrowHorizontal.gameObject.SetActive(true);
                break;
            
        }
    }



}
