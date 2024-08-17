using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameloopManager : MonoBehaviour
{
    [SerializeField] Button restartLevelButton;

    private void Awake()
    {
        restartLevelButton.onClick.AddListener(RestartLevel);
    }

    private void RestartLevel()
    {
        // Get the name of the current active scene
        string sceneName = SceneManager.GetActiveScene().name;

        // Reload the current scene
        SceneManager.LoadScene(sceneName);
    }
}
