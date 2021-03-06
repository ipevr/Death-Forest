﻿using System;
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
        [SerializeField] int lifes = 3;

        int level = 1;
        int score = 0;

        public UnityEvent OnNextLevelPrepared;
        public UnityEvent OnRepeatLevel;
        public UnityEvent OnGameOver;

        public int GetTreeNumber()
        {
            return trees;
        }

        public int GetCurrentLevel()
        {
            return level;
        }

        public int GetCurrentScore()
        {
            return score;
        }

        public int GetLifes()
        {
            return lifes;
        }

        public void LevelCompleted()
        {
            trees += treesAddedPerLevel;
            level++;
            OnNextLevelPrepared.Invoke();
        }

        public void PlayerDied()
        {
            lifes--;
            if (lifes < 0)
            {
                OnGameOver.Invoke();
            }
            else
            {
                OnRepeatLevel.Invoke();
            }
        }
    }
}
