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
        [SerializeField] private CrateListSO[] Crates;
        [SerializeField] private DangerPointListSO DangerPoints;

        [SerializeField] private Column[] Columns;

        private int ColumnCounter = 0;

        public enum BossState
        {
            
        }


        private void Start()
        {
            foreach (Column column in Columns)
            {
                column.ColumnDestroyed += ColumnOnColumnDestroyed;
                ColumnCounter++;
            }
        }

        private void ColumnOnColumnDestroyed(object sender, EventArgs e)
        {
            if (--ColumnCounter == 0)
            {
                GameManager.Instance.EnemyDied();
            }
        }


        
        
        
    }
}