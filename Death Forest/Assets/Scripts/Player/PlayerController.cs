using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathForest.Controller;

namespace DeathForest.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Keyboard Settings")]
        [SerializeField] KeyCode left = KeyCode.A;
        [SerializeField] KeyCode right = KeyCode.D;
        [SerializeField] KeyCode up = KeyCode.W;
        [Header("Speed")]
        [SerializeField] float speedForward = 1f;
        [SerializeField] float speedMutliplicator = 10f;
        [SerializeField] float speedSidewards = 2f;
        [Header("Control")]
        [SerializeField] float leftBorder = -10f;
        [SerializeField] float rightBorder = 10f;
        [SerializeField] float startDelay = 2f;

        GameManager gameManager;
        bool levelCompleted = false;
        bool isDead = false;
        bool started = false;
        Vector2 startPos;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.OnNextLevelPrepared.AddListener(StartNewLevel);
        }

        private IEnumerator Start()
        {
            startPos = transform.position;

            yield return new WaitForSeconds(startDelay);
            
            started = true;
        }

        private void Update()
        {
            CheckForEarlyStart();

            if (!started || levelCompleted || isDead)
            {
                return;
            }

            CheckKeyInput();

            Vector3 transVec = Vector3.up * speedForward * Time.deltaTime * (Input.GetKey(up) ? speedMutliplicator : 1);
            transform.Translate(transVec);
        }

        public void HandleUpperLimitReached()
        {
            levelCompleted = true;
            gameManager.LevelCompleted();
        }

        public void HandleEnemyCollision()
        {
            isDead = true;
        }

        private void StartNewLevel()
        {
            transform.position = startPos;
            levelCompleted = false;
            isDead = false;
            started = false;
            StartCoroutine(Start());
        }

        private void CheckForEarlyStart()
        {
            if (started) { return; }

            if (Input.GetKeyDown(up) || Input.GetKeyDown(left) || Input.GetKeyDown(right))
            {
                started = true;
            }
        }

        private void CheckKeyInput()
        {
            if (Input.GetKey(left))
            {
                transform.Translate(Vector3.left * speedSidewards * Time.deltaTime);
            }
            if (Input.GetKey(right))
            {
                transform.Translate(Vector3.right * speedSidewards * Time.deltaTime);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftBorder, rightBorder), transform.position.y, transform.position.z);
        }
    }
}
