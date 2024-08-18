using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameloopManager : MonoBehaviour
{
    [SerializeField] private Button restartLevelButtonInGame;

    [SerializeField] private Button restartLevelButtonGameOverMenu;

    [SerializeField] private Button loadNextLevelButton;

    [SerializeField] string nextLevelName;

    public event UnityAction OnCantLoadNextLevel;

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
        // No more levels (should probably check build scene index but this is fine)
        if (string.IsNullOrWhiteSpace(nextLevelName))
        {
            OnCantLoadNextLevel?.Invoke();
        }
        else
        {
            Utils.LoadNextLevel(nextLevelName);
        }
    }
}
