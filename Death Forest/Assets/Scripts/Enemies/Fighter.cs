using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathForest.Player;

namespace DeathForest.Enemies
{
    public class Fighter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>())
            {
                collision.GetComponent<PlayerController>().HandleEnemyCollision();
            }
        }
    }
}