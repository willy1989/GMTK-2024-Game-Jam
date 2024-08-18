using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform gameOverMenu;

    [SerializeField] private RectTransform levelCompleteMenu;

    [SerializeField] private PlayerDeath playerDeath;

    [SerializeField] private EndOfLevelZone endOfLevelZone;

    private void Awake()
    {
        playerDeath.playerDeathEvent += () => ToggleGameOverMenu(onOff: true);
        endOfLevelZone.EndOfLevelReachedEvent += () => TogglelevelCompleteMenu(onOff: true);
    }

    private void ToggleGameOverMenu(bool onOff)
    {
        gameOverMenu.gameObject.SetActive(onOff);
    }

    private void TogglelevelCompleteMenu(bool onOff)
    {
        levelCompleteMenu.gameObject.SetActive(onOff);
    }
}
