using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeathForest.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] KeyCode left = KeyCode.A;
        [SerializeField] KeyCode right = KeyCode.D;
        [SerializeField] KeyCode up = KeyCode.W;
        [SerializeField] float speedForward = 1f;
        [SerializeField] float speedSidewards = 2f;
        [SerializeField] float leftBorder = -10f;
        [SerializeField] float rightBorder = 10f;
        
        bool levelCompleted = false;

        private void Update()
        {
            if (levelCompleted)
            {
                return;
            }

            CheckKeyInput();

            transform.Translate(Vector3.up * speedForward * Time.deltaTime);
        }

        public void HandleUpperLimitReached()
        {
            levelCompleted = true;
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
