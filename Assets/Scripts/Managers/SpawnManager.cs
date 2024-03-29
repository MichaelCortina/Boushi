using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private List<Vector3> spawnPoints; 

        private void Awake()
        {
            int index = PlayerPrefs.GetInt("SpawnPoint");
            playerTransform.position = spawnPoints[index];
        }
    }
}