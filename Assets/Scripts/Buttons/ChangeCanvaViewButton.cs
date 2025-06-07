using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCanvaViewButton : MonoBehaviour
{
    [SerializeField] private Transform ViewToHide;
    [SerializeField] private Transform ViewToShow;
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }


    private void OnClick()
    {
        print("KKliknięto!");
        ViewToHide.gameObject.SetActive(false);
        ViewToShow.gameObject.SetActive(true);
    }
}
