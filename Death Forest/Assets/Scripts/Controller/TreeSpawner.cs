using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeathForest.Controller
{
    public class TreeSpawner : MonoBehaviour
    {
        [SerializeField] GameObject[] treePrefabs = null;
        [SerializeField] float upperLimit = 10f;
        [SerializeField] float lowerLimit = 0f;
        [SerializeField] float leftLimit = -10f;
        [SerializeField] float rightLimit = 10f;

        GameManager gameManager;

        private void Awake()
        {
            gameManager = FindObjectOfType<GameManager>();
            gameManager.OnNextLevelPrepared.AddListener(StartNextLevel);
        }

        private void Start()
        {
            SpawnTrees();
        }

        private void SpawnTrees()
        {
            DestroyOldTrees();

            for (int i = 0; i < gameManager.GetTreeNumber(); i++)
            {
                GameObject tree = Instantiate(treePrefabs[Random.Range(0, treePrefabs.Length)], transform);
                float xPos = Random.Range(leftLimit, rightLimit);
                float yPos = Random.Range(lowerLimit, upperLimit);

                tree.transform.position = new Vector2(xPos, yPos);
            }
        }

        private void DestroyOldTrees()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void StartNextLevel()
        {
            SpawnTrees();
        }

    }
}
