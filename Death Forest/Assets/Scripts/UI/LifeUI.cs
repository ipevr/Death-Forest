using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeathForest.UI
{
    public class LifeUI : MonoBehaviour
    {
        [SerializeField] GameObject lifePrefab;

        public void UpdateLifes(int number)
        {
            DestroyLifeIcons();

            for (int i = 0; i < number; i++)
            {
                Instantiate(lifePrefab, transform);
            }
        }

        private void DestroyLifeIcons()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
