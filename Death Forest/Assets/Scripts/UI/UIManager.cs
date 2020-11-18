using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DeathForest.Controller;
using System;

namespace DeathForest.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Text scoreText = null;
        [SerializeField] Text levelText = null;
        [SerializeField] Text treesText = null;

        GameManager gameManager;
        LifeUI lifeUi;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.OnNextLevelPrepared.AddListener(UpdateUI);
            gameManager.OnRepeatLevel.AddListener(UpdateUI);

            lifeUi = GetComponentInChildren<LifeUI>();
        }

        private void Start()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            scoreText.text = gameManager.GetCurrentScore().ToString();
            levelText.text = gameManager.GetCurrentLevel().ToString();
            treesText.text = gameManager.GetTreeNumber().ToString();
            lifeUi.UpdateLifes(gameManager.GetLifes());
        }
    }
}
