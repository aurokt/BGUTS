using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    private int currentLevelIndex = 1; 

    
    public void LoadNextLevel()
    {
        
        currentLevelIndex++;

        
        if (currentLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentLevelIndex);
        }
        else
        {
            Debug.LogWarning("No more levels available.");
        }
    }

    
    public void LoadLevelByIndex(int levelIndex)
    {
        if (levelIndex >= 1 && levelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.LogWarning("Invalid level index.");
        }
    }

    
    public void LoadLevelByName(string levelName)
    {
        if (!string.IsNullOrEmpty(levelName))
        {
            SceneManager.LoadScene(levelName);
        }
        else
        {
            Debug.LogWarning("Invalid level name.");
        }
    }
}
