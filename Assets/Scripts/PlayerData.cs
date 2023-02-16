using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private ArrayList completedLevels;
    private string sceneName;
    private Vector3 playerPosition;
    public ArrayList getCompletedLevels()
    {
        return completedLevels;
    }

    public string getSceneName()
    {
        return sceneName;
    }

    public Vector3 getPlayerPosition()
    {
        return playerPosition;
    }
}
