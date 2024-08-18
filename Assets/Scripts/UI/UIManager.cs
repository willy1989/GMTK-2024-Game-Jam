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

    private void ToggleGameOverMenu(bool onOff)
    {
        gameOverMenu.gameObject.SetActive(onOff);
    }

    private void TogglelevelCompleteMenu(bool onOff)
    {
        levelCompleteMenu.gameObject.SetActive(onOff);
    }

    private void Update()
    {
        if (!tutorialOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            var isOpen = levelSelector.activeSelf;
            levelSelector.SetActive(!isOpen);

            if (isOpen)
            {
                OnClosed?.Invoke();
            }
            else
            {
                OnOpened?.Invoke();
            }
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
    }
}
