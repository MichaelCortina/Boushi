using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveSystem
{
    public class PlayerData
    {
        private List<Scene> completedLevels;
    
        private List<Scene> visitedLevels;
    
        private string sceneName;

        private float[] playerPosition;

        public PlayerData(PlayerInfo playerInfo)
        {
            completedLevels = playerInfo.CompletedLevels;
        
            visitedLevels = playerInfo.VisitedLevels;
        
            sceneName = playerInfo.Scene.name;

            playerPosition = new float[3];
            playerPosition[0] = playerInfo.transform.position.x;
            playerPosition[1] = playerInfo.transform.position.y;
            playerPosition[2] = playerInfo.transform.position.z;
        }
    }
}
