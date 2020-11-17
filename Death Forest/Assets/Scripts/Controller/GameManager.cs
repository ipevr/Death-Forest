using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DeathForest.Controller
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int trees = 20;
        [SerializeField] int treesAddedPerLevel = 5;

        public UnityEvent OnNextLevelPrepared;

        public int GetTreeNumber()
        {
            return trees;
        }

        public void LevelCompleted()
        {
            trees += treesAddedPerLevel;
            OnNextLevelPrepared.Invoke();
        }
    }
}
