using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData
{
    private ArrayList completedLevels = new ArrayList();
    
    private string sceneName;

    private Vector3 playerPosition;

    public PlayerSaveData(PlayerData playerData)
    {
        completedLevels = playerData.getCompletedLevels();
        
        sceneName = playerData.getSceneName();

        playerPosition = playerData.getPlayerPosition();
    }
}
