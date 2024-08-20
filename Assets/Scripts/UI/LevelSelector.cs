using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Config config;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Button closeButton;

    public event UnityAction OnLevelSelectorClosed;

    private void Start()
    {
        closeButton.onClick.AddListener(OnClosed);

        foreach (var level in config.Levels)
        {
            var button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TMP_Text>().text = level.DisplayName ?? level.SceneName;
            button.GetComponent<Button>().onClick.AddListener(() => OnLevelButtonClicked(level.SceneName));
        }
    }

    private void OnLevelButtonClicked(string sceneName)
    {
        Debug.Log("Level selected: " + sceneName);
        Utils.LoadNextLevel(sceneName);
    }

    private void OnClosed()
    {
        OnLevelSelectorClosed?.Invoke();
    }
}
