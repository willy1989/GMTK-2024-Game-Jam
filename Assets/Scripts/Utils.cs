using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utils
{
    public static bool ComparePlayerTag(this Collider2D collider)
    {
        return collider.gameObject.ComparePlayerTag();
    }

    public static bool ComparePlayerTag(this GameObject gameObject)
    {
        return gameObject.CompareTag("Player");
    }

    public static void RestartLevel()
    {
        // Get the name of the current active scene
        string sceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadNextLevel(string nextLevelName)
    {
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            // Unload the current active scene
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            // Load the new scene
            SceneManager.LoadSceneAsync(nextLevelName);
        }
        else
        {
            Debug.LogError("Next level scene name is empty or null!");
        }
    }
}
