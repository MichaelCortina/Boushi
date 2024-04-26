using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<Vector3> spawnPoints; 

        private void Awake()
        {
            
            // Spawning Player
            GameObject playerResource = Resources.Load<GameObject>(PlayerState.PlayerName);
            Vector3 position = spawnPoints[GameState.PlayerState.SpawnPoint];
            Quaternion rotation = Quaternion.identity;
            
            GameObject playerWrapper = Instantiate(playerResource, position, rotation);
            GameObject player = playerWrapper.transform.GetChild(0).gameObject;
            GameState.InitPlayer(player);
        }
    }
}