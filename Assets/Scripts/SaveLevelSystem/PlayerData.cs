using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerData
{
    private List<Scene> completedLevels;

    private readonly float[] playerPosition;

    private string sceneName;

    private List<Scene> visitedLevels;

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