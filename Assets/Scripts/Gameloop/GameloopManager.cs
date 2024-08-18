using UnityEngine;
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
        Utils.RestartLevel();
    }

    public void LoadNextLevel()
    {
        Utils.LoadNextLevel(nextLevelName);
    }
}
