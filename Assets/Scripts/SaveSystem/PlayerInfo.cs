using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace SaveSystem
{
    public class PlayerInfo : MonoBehaviour
    {
        private ArrayList completedLevels;
        private ArrayList visitedLevels;
        [SerializeField] private Scene currScene;


        #region Adding Methods
    
        public void AddCompletedLevel(Object completed)
        {
            completedLevels.Add(completed);
        }
        public void AddVisitedLevel(Object visited)
        {
            visitedLevels.Add(visited);
        }
    
        #endregion
    
        #region Removing Methods
        public void RemoveCompletedLevel(Object completed)
        {
            completedLevels.Remove(completed);
        }
        public void RemoveVisitedLevel(Object visited)
        {
            visitedLevels.Remove(visited);
        }
        #endregion
    
        #region getters
        public ArrayList GetCompletedLevels()
        {
            return completedLevels;
        }
        public ArrayList GetVisitedLevels()
        {
            return visitedLevels;
        }
        public Scene GetScene()
        {
            return currScene;
        }
        #endregion

        private void Awake()
        {
            currScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            if(!visitedLevels.Contains(currScene))
            {
                visitedLevels.Add(currScene);
            }
        }
    
    }
}
