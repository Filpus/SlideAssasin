using LDtkUnity;
using System;
using UnityEngine;

public class LvlExit : MonoBehaviour, ILDtkImportedEntity
{

    [SerializeField] private LvlExitVisual lvlExitVisual;

    public event EventHandler OnEndLevel;
    public bool IsAvtive = false;
    void Start()
    {
        GameManager.Instance.LevelCleared += GameManagerOnLevelCleared;
    }

    public void OnLDtkImportEntity(EntityInstance entity)
    {

    }

    private void GameManagerOnLevelCleared(object sender, EventArgs e)
    {
        IsAvtive = true;
        lvlExitVisual.ShowActive();
    }


    private void OnTriggerEnter(Collider other)
    {
        print("test");
        if (IsAvtive)
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        OnEndLevel?.Invoke(this, EventArgs.Empty);
    }
}
