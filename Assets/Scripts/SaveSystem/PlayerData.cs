using System.Collections;

namespace SaveSystem
{
    public class PlayerData
    {
        private ArrayList completedLevels;
    
        private ArrayList visitedLevels;
    
        private string sceneName;

        private float[] playerPosition;

        public PlayerData(PlayerInfo playerInfo)
        {
            completedLevels = playerInfo.GetCompletedLevels();
        
            visitedLevels = playerInfo.GetVisitedLevels();
        
            sceneName = playerInfo.GetScene().name;

            playerPosition = new float[3];
            playerPosition[0] = playerInfo.transform.position.x;
            playerPosition[1] = playerInfo.transform.position.y;
            playerPosition[2] = playerInfo.transform.position.z;
        }
    }
}
