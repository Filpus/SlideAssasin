using LDtkUnity;
using System;
using UnityEngine;

public class LvlExit : MonoBehaviour, ILDtkImportedEntity
{

    [SerializeField] private LvlExitVisual lvlExitVisual;

    private bool IsAvtive = false;
    void Start()
    {
        GameManager.LevelCleared += GameManagerOnLevelCleared;
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
        if (IsAvtive)
        {
            EndLevel();
        }
    }

    private void EndLevel()
    {
        //TODO zaimplementować koniec poziomu
    }
}
