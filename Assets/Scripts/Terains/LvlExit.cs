using LDtkUnity;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class LvlExit : MonoBehaviour, ILDtkImportedEntity
{

    //[SerializeField] private LvlExitVisual lvlExitVisual;


    public static LvlExit Instance; 

    public event EventHandler OnEndLevel;
    public bool IsActive = false;


    [SerializeField] private LvlExitAnimator _animator;

    void Awake()
    {
        if (LvlExit.Instance != null)
        {
            GameManager.Instance.LevelCleared -= Instance.GameManagerOnLevelCleared;
            Destroy(Instance.gameObject);
            Instance = this;
            Instance.OnEndLevel += GameManager.Instance.LevelExitOnOnEndLevel;
        }
        else
        {

            Instance = this;
        }
    }
    void Start()
    {


        GameManager.Instance.LevelCleared += GameManagerOnLevelCleared;
    }

    public void OnLDtkImportEntity(EntityInstance entity)
    {

    }

    private void GameManagerOnLevelCleared(object sender, EventArgs e)
    {
        IsActive = true;
        _animator.Open();
    }
    
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsActive)
        {
            EndLevel();
            Debug.Log("EndLevel");
        }
    }

    private void EndLevel()
    {
        OnEndLevel?.Invoke(this, EventArgs.Empty);
    }
}
