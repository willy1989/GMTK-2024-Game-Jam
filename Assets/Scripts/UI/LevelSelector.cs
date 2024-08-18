using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private Config config;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonContainer;

    private void Start()
    {
        foreach (var level in config.Levels)
        {
            var button = Instantiate(buttonPrefab, buttonContainer);
            button.GetComponentInChildren<TMP_Text>().text = level.SceneName;
            button.GetComponent<Button>().onClick.AddListener(() => OnLevelButtonClicked(level.SceneName));
        }
    }

    private void OnLevelButtonClicked(string sceneName)
    {
        Debug.Log("Level selected: " + sceneName);
        Utils.LoadNextLevel(sceneName);
    }
}
