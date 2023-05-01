using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Scene currScene;

    public List<Scene> CompletedLevels { get; } = new();
    public List<Scene> VisitedLevels { get; } = new();

    public Scene Scene => currScene;

    private void Awake()
    {
        currScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        if (!VisitedLevels.Contains(currScene)) VisitedLevels.Add(currScene);
    }


    #region Adding Methods

    public void AddCompletedLevel(Scene completed)
    {
        CompletedLevels.Add(completed);
    }

    public void AddVisitedLevel(Scene visited)
    {
        VisitedLevels.Add(visited);
    }

    #endregion

    #region Removing Methods

    public void RemoveCompletedLevel(Scene completed)
    {
        CompletedLevels.Remove(completed);
    }

    public void RemoveVisitedLevel(Scene visited)
    {
        VisitedLevels.Remove(visited);
    }

    #endregion
}