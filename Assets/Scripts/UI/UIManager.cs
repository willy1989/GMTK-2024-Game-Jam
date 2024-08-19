using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform gameOverMenu;

    [SerializeField] private RectTransform levelCompleteMenu;

    [SerializeField] private PlayerDeath playerDeath;

    [SerializeField] private EndOfLevelZone endOfLevelZone;

    [SerializeField] private GameObject levelSelector;
    private bool tutorialOpen;

    public event UnityAction OnOpened;
    public event UnityAction OnClosed;

    private void Awake()
    {
        playerDeath.playerDeathEvent += () => ToggleGameOverMenu(onOff: true);
        endOfLevelZone.EndOfLevelReachedEvent += () => TogglelevelCompleteMenu(onOff: true);

        var tm = FindObjectOfType<TutorialManager>();
        tm.OnTutorialOpened += OnTutorialOpened;
        tm.OnTutorialClosed += OnTutorialClosed;

        var gm = FindObjectOfType<GameloopManager>();
        gm.OnCantLoadNextLevel += OnCantLoadNextLevel;
        gm.OnLevelSelectorOpened += () => ToggleLevelSelector(onOff: true);

        ToggleLevelSelector(onOff: false);
        var ls = levelSelector.GetComponent<LevelSelector>();
        ls.OnLevelSelectorClosed += () => ToggleLevelSelector(onOff: false);
    }

    private void OnTutorialOpened()
    {
        tutorialOpen = true;
        OnOpened?.Invoke();
    }

    private void OnTutorialClosed()
    {
        tutorialOpen = false;
        OnClosed?.Invoke();
    }

    private void OnCantLoadNextLevel()
    {
        Debug.Log("[ui] can't load next level so opening level selector");
        ToggleLevelSelector(onOff: true);
    }

    private void ToggleGameOverMenu(bool onOff)
    {
        gameOverMenu.gameObject.SetActive(onOff);
    }

    private void TogglelevelCompleteMenu(bool onOff)
    {
        levelCompleteMenu.gameObject.SetActive(onOff);
    }

    private void ToggleLevelSelector(bool onOff)
    {
        levelSelector.SetActive(onOff);

        if (onOff)
        {
            OnOpened?.Invoke();
        }
        else
        {
            OnClosed?.Invoke();
        }
    }

    private void Update()
    {
        if (!tutorialOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            //ToggleLevelSelector(!levelSelector.activeSelf);
        }
    }

    private void OnDestroy()
    {
        var tm = FindObjectOfType<TutorialManager>();
        if (tm != null)
        {
            tm.OnTutorialOpened -= OnTutorialOpened;
            tm.OnTutorialClosed -= OnTutorialClosed;
        }

        var gm = FindObjectOfType<GameloopManager>();
        if (gm != null)
        {
            gm.OnCantLoadNextLevel -= OnCantLoadNextLevel;
        }
    }
}
