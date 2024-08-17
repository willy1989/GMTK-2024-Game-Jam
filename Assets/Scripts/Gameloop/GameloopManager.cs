using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameloopManager : MonoBehaviour
{
    [SerializeField] private Button restartLevelButtonInGame;

    [SerializeField] private Button restartLevelButtonGameOverMenu;

    [SerializeField] private Button loadNextLevelButton;

    [SerializeField] string nextLevelName;

    private void Awake()
    {
        restartLevelButtonInGame.onClick.AddListener(RestartLevel);
        restartLevelButtonGameOverMenu.onClick.AddListener(RestartLevel);
        loadNextLevelButton.onClick.AddListener(LoadNextLevel);

    }

    private void RestartLevel()
    {
        // Get the name of the current active scene
        string sceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextLevel()
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
