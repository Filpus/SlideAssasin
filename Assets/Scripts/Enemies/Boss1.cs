using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Terains;
using UnityEngine;
using UnityEngine.UIElements;

namespace Enemies
{
    
    public class Boss1 : MonoBehaviour
    {
        [SerializeField] private CrateList Crates;
        [SerializeField] private DangerPointList DangerPoints;

        [SerializeField] private BossAnimator _animator;
        [SerializeField] private Column[] Columns;


        [SerializeField] private int StateLength = 3;
        private int Counter = 0;

        private int ColumnCounter = 0;

        private int lastChangedCrateGroup = 1;

        public enum BossState
        {
            Safe,
            Attacked,
            Impatient,
            Watchful
            
        }


        private BossState currentState = BossState.Safe;
        private void Start()
        {
            foreach (Column column in Columns)
            {
                column.ColumnDestroyed += ColumnOnColumnDestroyed;
                column.ColumnGetHit += ColumnOnColumnGetHit;
                ColumnCounter++;
            }
            Player.Instance.PlayerEndMovement += InstanceOnPlayerEndMovement;
        }



        private void InstanceOnPlayerEndMovement(object sender, EventArgs e)
        {
            DangerPoints.MakeProgressForAll();

            switch (currentState)
            {
                case BossState.Attacked:
                    print("Attacked");
                    Crates.SwitchSelectedGroup(3);
                    Crates.SwitchSelectedGroup(2);
                    DangerPoints.ActiveSelectedGroup(2);

                    Counter++;
                    if (Counter % StateLength == 0)
                    {
                        Counter = 0;
                        ChangeStateToNext();
                    }
                    break;
                case BossState.Impatient:
                    print("Impatient");

                    Crates.SwitchSelectedGroup(1);
                    break;
                case BossState.Watchful:
                    print("Watchfull");

                    Crates.SwitchSelectedGroup(lastChangedCrateGroup);
                    if (--lastChangedCrateGroup == 0)
                    {
                        lastChangedCrateGroup = 3;
                    }
                    break;
                default:
                    print("safe");
                    break;
            }
        }

        private void ColumnOnColumnGetHit(object sender, EventArgs e)
        {
            currentState = BossState.Attacked;
        }
        private void ColumnOnColumnDestroyed(object sender, EventArgs e)
        {
            if (--ColumnCounter == 0)
            {
                GameManager.Instance.EnemyDied();
            }
        }

        private void ChangeStateToNext()
        {
            switch (currentState)
            {
                case BossState.Attacked:
                    DangerPoints.ActiveSelectedGroup(3);
                    currentState = BossState.Impatient;
                    break;
                case BossState.Impatient:
                    currentState = BossState.Watchful;
                    break;
                case BossState.Watchful:
                    currentState = BossState.Safe;
                    break;
            }
        }
        
        
        
        
        
    }
}